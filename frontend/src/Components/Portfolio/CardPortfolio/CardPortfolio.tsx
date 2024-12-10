import React from "react";
import DeletePortfolio from "../DeletePortfolio/DeletePortfolio";
import { Link } from "react-router-dom";
import { PortfolioGet } from "../../../Models/Portfolio";

interface Props {
    portfolioValue: PortfolioGet;
    onPortfolioDelete: (e: SyntheticEvent) => void;
}

const CardPortfolio = ({ portfolioValue, onPortfolioDelete }: Props) => {
    //console.log(portfolioValue.brand);
    return (
        <div className="flex flex-col w-full p-8 space-y-4 text-center rounded-lg shadow-lg md:w-1/3">
            <Link to={`/ticket/brand/${portfolioValue.brand}/`} className="pt-6 text-xl font-bold">{portfolioValue.brand}</Link>
            <DeletePortfolio onPortfolioDelete={onPortfolioDelete} portfolioValue={portfolioValue.brand} />
        </div>
    );
};

export default CardPortfolio;