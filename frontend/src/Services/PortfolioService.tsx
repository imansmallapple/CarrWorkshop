import axios from "axios";
import { PortfolioGet, PortfolioPost } from "../Models/Portfolio";
import { handleError } from "../Helpers/ErrorHandler";
import { SearchResponse } from "../api";
//import { useState } from "react";
//import { TicketProfile } from "../ticket";
//import { UpdateTicketStateProcessing } from "../api";

const api = "https://localhost:7201/api/Dashboard";

export const getTicketId = async (brand: string): Promise<string> => {
    const data = await axios.get<PortfolioPost>(api + `?brand=${brand}`);
    const ticketId = data.data[data.data.length-1].id;
    //console.log(data);
    return ticketId;
}

export const getTicketIdToDelete = async (brand: string): Promise<string> => {
    const data = await axios.get<SearchResponse>(
        `https://localhost:7201/api/Ticket?Brand=${brand}`
    );
    //console.log(data);
    const ticketId = data.data[0].id;
    return ticketId;
}

export const getOneTicket = async (query: string) => {
    const data = await axios.get<PortfolioPost>(`https://localhost:7201/api/Ticket/${query}`);
    //console.log(data.data);
    return data.data;
}

//Consider to add/delete API via Ticket Id rather than brand
export const portfolioAddAPI = async (brand: string) => {
    //const [updateTicket, setUpdateTicket] = useState<TicketProfile>();
    try {
        const data = await axios.post<PortfolioPost>(api + `?brand=${brand}`);
        //console.log(data);
        //const ticketId = data.data[0].id;
        //console.log(ticketId);
        //setUpdateTicket({ stateCategory: 1 });
        //UpdateTicketStateProcessing(ticketId);
        return data;
    } catch (error) {
        handleError(error);
    }
};

export const portfolioDeleteAPI = async (brand: string) => {
    try {
        const data = await axios.delete<PortfolioPost>(api + `?brand=${brand}`);
        return data;
    } catch (error) {
        handleError(error);
    }
};

export const portfolioGetAPI = async () => {
    try {
        const data = await axios.get<PortfolioGet[]>(api);
        return data;
    } catch (error) {
        handleError(error);
    }
};