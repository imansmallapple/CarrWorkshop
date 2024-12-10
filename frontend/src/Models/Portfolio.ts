export type PortfolioGet = {
    id: number;
	brand: string;
	model: string;
	description: string;
	registrationId: string;
	//employeeAssigned: string;
};

export type PortfolioPost = {
	id: number;
	brand: string;
	stateCategory: number;
};