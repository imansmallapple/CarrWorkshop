import React, { useEffect, useState } from "react";
import { TicketProfile } from "../../ticket";
import { useParams } from "react-router-dom";
import { getTicketProfile } from "../../api";
import Sidebar from "../../Components/Sidebar/Sidebar";
import TicketDashboard from "../../Components/TicketDashboard/TicketDashboard";
import Tile from "../../Components/Tile/Tile";
interface Props { }

const TicketPage = (props: Props) => {
    const {ticker} = useParams();
    const [ticket, setTicket] = useState<TicketProfile>();
    const [isLoading, setIsLoading] = useState(true);
    useEffect(() => {
        const getProfileInit = async () => {
            try {
                const result = await getTicketProfile(ticker!);
                console.log(ticker!);
                //setTicket(result);
                setTicket(result?.data);
                setIsLoading(false);
            }
            catch (error) {
                console.error(error);
            }
        };
        getProfileInit();
    }, []);
    const getStateCategory = (stateCategory: number) => {
        if (stateCategory === 0) {
            return "Created";
        }
        else if (stateCategory === 1) {
            return "Processing";
        }
        else if (stateCategory === 2) {
            return "Done";
        }
        else if (stateCategory === 3) {
            return "Closed";
        }
        // Add other conditions here if needed
        return stateCategory;
    };
    if (isLoading) {
        return <div>Isloading...</div>;
    }
    return (
        <>
            <div className="w-full relative flex ct-docs-disable-sidebar-content overflow-x-hidden">            
                <Sidebar />
                <TicketDashboard>
                    <Tile title="Brand" subTitle={ticket.brand }></Tile>
                    <Tile title="Model" subTitle={ticket.model }></Tile>
                    <Tile title="Registration ID" subTitle={ticket.registrationId}></Tile>
                    <Tile title="Description" subTitle={ticket.description}></Tile>
                    <Tile title="Mechanic Assigned" subTitle={ticket.employeeAssigned}></Tile>
                    <Tile title="Ticket Status" subTitle={getStateCategory(ticket.stateCategory)}></Tile>
                    <Tile title="Total Cost" subTitle={`￥${ticket.totalPrice}`}></Tile>
                </TicketDashboard>
            </div>
        </>
    );
};

export default TicketPage;