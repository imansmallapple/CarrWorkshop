//https://localhost:7201/api/Ticket?Brand=test1
import axios from "axios";
import {
    TicketSearch, TicketProfile
} from "./ticket";

export interface SearchResponse {
    data: TicketSearch[];
}

export const searchTickets = async (brand: string) => {
    try {
        const data = await axios.get<SearchResponse>(
            `https://localhost:7201/api/Ticket?Brand=${brand}`
        );
        return data;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
            return error.message;
        } else {
            console.log("unexpected error: ", error);
            return "An expected error has occured.";
        }
    }
};

export const getTicketProfile = async (query: string) => {
    try {
        const data = await axios.get<TicketProfile>(
            `https://localhost:7201/api/Ticket/${query}`
        );
        return data;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
            return error.message;
        } else {
            console.log("unexpected error: ", error);
            return "An expected error has occured.";
        }
    }
}

export const getAllTickets = async () => {
    try {
        const data = await axios.get<TicketProfile[]>(
            `https://localhost:7201/api/Ticket`
        );
        return data;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
            return error.message;
        } else {
            console.log("unexpected error: ", error);
            return "An expected error has occured.";
        }
    }
}

export const GetTicket = async (query: string) => {
    try {
        const data = await axios.get<TicketSearch[]>(
            `https://localhost:7201/api/Ticket/${query}`
        );
        return data;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
            return error.message;
        } else {
            console.log("unexpected error: ", error);
            return "An expected error has occured.";
        }
    }
}

export const PostTicket = async (ticket: TicketProfile) => {
    try {
        const data = await axios.post<TicketProfile[]>(
            `https://localhost:7201/api/Ticket`, ticket
        );
        return data;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
            return error.message;
        } else {
            console.log("unexpected error: ", error);
            return "An expected error has occured.";
        }
    }
}

export const UpdateTicket = async (query: string, ticket: TicketProfile) => {
    try {
        const data = await axios.put<TicketProfile>(
            `https://localhost:7201/api/Ticket/${query}`, ticket
        );
        return data;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
            return error.message;
        } else {
            console.log("unexpected error: ", error);
            return "An expected error has occured.";
        }
    }
}