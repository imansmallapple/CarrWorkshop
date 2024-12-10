import React, { useState, ChangeEvent, SyntheticEvent, useEffect } from "react";
import { TicketProfile, TicketSearch } from "../../ticket";
import { GetTicket, searchTickets } from "../../api";
import Search from "../../Components/Search/Search";
import ListPortfolio from "../../Components/Portfolio/ListPortfolio/ListPortfolio";
import CardList from "../../Components/CardList/CardList";
import { getOneTicket, getTicketId, getTicketIdToDelete, portfolioAddAPI, portfolioDeleteAPI, portfolioGetAPI } from "../../Services/PortfolioService";
import { PortfolioGet } from "../../Models/Portfolio";
import { toast } from "react-toastify";
import { getAllTickets } from "../../api";
import { UpdateTicket } from "../../api";
import { useAuth } from "../../Context/UseAuth"

interface Props { }

const SearchPage = (props: Props) => {
    const [search, setSearch] = useState<string>("");
    const [portfolioValues, setPortfolioValues] = useState<PortfolioGet[] | null>([]);
    const [searchResult, setSearchResult] = useState<TicketSearch[]>([]);
    const [serverError, setServerError] = useState<string | null>(null);
    const [updateTicket, setUpdateTicket] = useState<TicketProfile>();
    const { user } = useAuth();

      useEffect(() => {
        getPortfolio();
        getAllTicketsAPI();
    }, []);

    const getAllTicketsAPI = async () => {
        const result = await getAllTickets();
        if (typeof result == "string") {
            setServerError(result);
        } else if (Array.isArray(result.data)) {
            setSearchResult(result.data);
        }
    };
    const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
        setSearch(e.target.value);
    };

    const getPortfolio = () => {
        portfolioGetAPI()
            .then((res) => {
                if (res?.data) {
                    setPortfolioValues(res?.data);
                }
            })
            .catch((e) => {
                setPortfolioValues(null);
            });
    };

    const onPortfolioCreate = async (e: any) => {
        e.preventDefault();

        //console.log(user?.userName);
        portfolioAddAPI(e.target[0].value)
            .then((res) => {
                if (res?.status === 200) {
                    toast.success("Ticket added to portfolio!");
                    getTicketId(e.target[0].value).then(id => {
                        console.log(id);
                        getOneTicket(id).then(
                            ticket => {
                                //console.log(ticket);
                                const updatedTicket = { ...ticket, stateCategory: 1, employeeAssigned: user?.userName };
                                UpdateTicket(id, updatedTicket);
                                getPortfolio();
                                //Update ticket state immediately
                                setSearchResult(prevSearchResult =>
                                    prevSearchResult.map(item =>
                                        item.id === id ? { ...item, stateCategory: 1, employeeAssigned: user?.userName } : item
                                    )
                                );
                           }
                        )
                    //setUpdateTicket({ stateCategory: 1 });
                    });
                }
            })
            .catch((e) => {
                toast.warning("Could not add ticket to portfolio!");
            });
    };

    const onPortfolioDelete = (e: any) => {
        e.preventDefault();
        portfolioDeleteAPI(e.target[0].value).then((res) => {
            if (res?.status == 200) {
                toast.success("Ticket deleted from portfolio!");
                getTicketIdToDelete(e.target[0].value).then(id => {
                    //console.log(id);
                    getOneTicket(id).then(
                        ticket => {
                            const updatedTicket = { ...ticket, stateCategory: 0, employeeAssigned: "Not Assigned Yet" };
                            UpdateTicket(id, updatedTicket);
                            getPortfolio();
                            //Update ticket state immediately
                            setSearchResult(prevSearchResult =>
                                prevSearchResult.map(item =>
                                    item.id === id ? { ...item, stateCategory: 0, employeeAssigned: "Not Assigned Yet" } : item
                                )
                            );
                        }
                    )
                    //setUpdateTicket({ stateCategory: 1 });
                });
                //setSearchResult(prevSearchResult =>
                //    prevSearchResult.map(item =>
                //        item.id === e.target[0].value ? { ...item, stateCategory: 0 } : item
                //    )
                //);
                //getPortfolio();
            }
        });
    };

    const onSearchSubmit = async (e: SyntheticEvent) => {
        e.preventDefault();
        const result = await searchTickets(search);
        if (typeof result == "string") {
            setServerError(result);
        } else if (Array.isArray(result.data)) {
            setSearchResult(result.data);
        }
        console.log(searchResult);
    };
    return (
        <>
            <Search
                onSearchSubmit={onSearchSubmit}
                search={search}
                handleSearchChange={handleSearchChange}
            />
            <ListPortfolio
                portfolioValues={portfolioValues!}
                onPortfolioDelete={onPortfolioDelete}
            />
            <CardList
                searchResults={searchResult}
                onPortfolioCreate={onPortfolioCreate}
            />

            {serverError && <div>Unable to connect to API</div>}
        </>
    );
};

export default SearchPage;