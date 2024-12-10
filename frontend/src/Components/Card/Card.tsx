import React, { SyntheticEvent } from "react";
import "./Card.css";
import { TicketSearch } from "../../ticket";
import AddPortfolio from "../Portfolio/AddPortfolio/AddPortfolio";
import { Link } from "react-router-dom";

interface Props{
    id: string;
    searchResult: TicketSearch;
    onPortfolioCreate: (e: SyntheticEvent) => void;
}

const Card: React.FC<Props> = ({ id, searchResult, onPortfolioCreate }: Props): JSX.Element => {
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
    return (
        <div
            className="flex flex-col items-center justify-between w-full p-6 bg-slate-100 rounded-lg md:flex-row"
            key={id}
            id={id}
        >
            <Link to={`/ticket/${searchResult.id}`} className="font-bold text-center text-veryDarkViolet md:text-left">
                {searchResult.brand} ({searchResult.model})
            </Link>
            <p className="text-veryDarkBlue">{searchResult.registrationId}</p>
            <p className="font-bold text-veryDarkBlue">
                {searchResult.employeeAssigned}
            </p>
            <p className="font-bold text-veryDarkBlue">
                {getStateCategory(searchResult.stateCategory)}
            </p>
            {searchResult.stateCategory == 0 && (<AddPortfolio onPortfolioCreate={onPortfolioCreate} brand={searchResult.brand} />)}
        </div>
    );
};

export default Card;