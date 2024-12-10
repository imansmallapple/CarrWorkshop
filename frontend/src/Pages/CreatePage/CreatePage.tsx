import React, { useState } from "react";
import { PostTicket } from "../../api";
import { useNavigate } from 'react-router-dom';

type Props = {};

const CreatePage = (props: Props) => {
    const [newTicket, setNewTicket] = useState<TicketProfile>({
        brand: "",
        model: "",
        description: "",
        employeeAssigned: "",
        registrationId: "",
        stateCategory: 0,
        totalPrice: 0,
        clientPaid: 0,
        acceptedOrNot: 0,
    });

    const onFormSubmit = (e: SyntheticEvent) => {
        e.preventDefault();
        let errors = {};
        if (newTicket.brand.length < 3) {
            errors.brand = "Brand must be in range 3-20 character long";
        }
        if (newTicket.model.length < 3) {
            errors.model = "Model must be in range 3-20 character long";
        }
        if (newTicket.registrationId.length < 3) {
            errors.registrationId = "Registration ID must be in range 3-20 character long";
        }

        if (Object.keys(errors).length > 0) {
            setErrors(errors);
            return;
        }
        PostTicket(newTicket)
            .then((res) => {
                console.log("OK");
                navigate('/search'); 
            })
            .catch((error) => {
                console.log("Not OK");
            });
        console.log(newTicket);
    };

    const [errors, setErrors] = useState("");
    const navigate = useNavigate();


    return (
        <>
            <form onSubmit={onFormSubmit}>                
                <div className="border-b border-gray-900/10 pb-12">
                    <h2 className="text-base font-semibold leading-7 text-gray-900">Ticket Information</h2>
                    <p className="mt-1 text-sm leading-6 text-gray-600">Please write the data carefully</p>

                    <div className="mt-10 grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6">
                        <div className="sm:col-span-1">
                            <label htmlFor="first-name" className="block text-sm font-medium leading-6 text-gray-900">
                                Brand
                            </label>
                            <div className="mt-2">
                                <input
                                    type="text"
                                    value={newTicket.brand}
                                    onChange={(e) =>
                                        setNewTicket({ ...newTicket, brand: e.target.value })
                                    }
                                    className="block w-half rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                />
                                {errors.brand && <p className="text-red-600">{errors.brand}</p>}
                            </div>
                        </div>

                        <div className="sm:col-span-1">
                            <label htmlFor="last-name" className="block text-sm font-medium leading-6 text-gray-900">
                                Model
                            </label>
                            <div className="mt-2">
                                <input
                                    type="text"
                                    value={newTicket.model}
                                    onChange={(e) =>
                                        setNewTicket({ ...newTicket, model: e.target.value })
                                    }
                                    className="block w-half rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                />
                                {errors.model && <p className="text-red-600">{errors.model}</p>}
                            </div>
                        </div>

                        <div className="sm:col-span-1">
                            <label htmlFor="email" className="block text-sm font-medium leading-6 text-gray-900">
                                Registration ID
                            </label>
                            <div className="mt-2">
                                <input
                                    id="registrationId"
                                    value={newTicket.registrationId}
                                    onChange={(e) =>
                                        setNewTicket({ ...newTicket, registrationId: e.target.value })
                                    }
                                    className="block w-half rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                />
                                {errors.registrationId && <p className="text-red-600">{errors.registrationId}</p>}
                            </div>
                        </div>          

                        <div className="col-span-full">
                            <label className="block text-sm font-medium leading-6 text-gray-900">
                                Description
                            </label>
                            <div className="mt-2">
                                <textarea
                                    type="text"
                                    value={newTicket.description}
                                    onChange={(e) =>
                                        setNewTicket({ ...newTicket, description: e.target.value })
                                    }
                                    rows={3}
                                    className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                />
                            </div>
                            <p className="mt-3 text-sm leading-6 text-gray-600">Write a few words about the ticket.</p>
                        </div>
                    </div>
                </div>
                <div className="mt-6 flex items-center justify-end gap-x-6">
                    <button type="button" className="text-sm font-semibold leading-6 text-gray-900">
                        Cancel
                    </button>
                    <button
                        type="submit"
                        className="rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
                    >
                        Submit
                    </button>
                </div>
            </form>       
        </>
    );
};

export default CreatePage;