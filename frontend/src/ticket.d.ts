export interface TicketSearch {
	id: number;
	brand: string;
	model: string;
	description: string;
	registrationId: string;
	stateCategory: number;
	employeeAssigned: string;
}

export interface TicketProfile {
	id: number;
	brand: string;
	model: string;
	description: string;
	employeeAssigned: string;
	registrationId: string;
	stateCategory: number;
	totalPrice: number;
	clientPaid: number;
	acceptedOrNot: number;
}