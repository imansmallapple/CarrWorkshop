import React from "react";
import Card from "../Card/Card";
import { TicketSearch } from "../../ticket";
import { v4 as uuidv4 } from "uuid";
interface Props {
    searchResults: TicketSearch[];
    onPortfolioCreate: (e: SyntheticEvent) => void;
}
{/*There is a problem for the conditions will execute twice so I simply put nothing, and I don't know how to avoid the length to be not undefined */ }
const CardList: React.FC<Props> = ({ searchResults, onPortfolioCreate }: Props): JSX.Element => {
    return (
        <>
            {searchResults?.length > 0 ? (
                searchResults.map((result) => {
                    return (
                        <Card id={result.brand} key={uuidv4()} searchResult={result} onPortfolioCreate={onPortfolioCreate} />
                    );
                })
            ) : (
                <></>
            )}
        </>
    );
};

export default CardList;