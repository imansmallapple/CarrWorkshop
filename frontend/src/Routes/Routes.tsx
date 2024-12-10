import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage/HomePage";
import TicketPage from "../Pages/TicketPage/TicketPage";
import SearchPage from "../Pages/SearchPage/SearchPage";
import LoginPage from "../Pages/LoginPage/LoginPage";
import RegisterPage from "../Pages/RegisterPage/RegisterPage";
import ProtectedRoute from "./ProtectedRoute";
import PartRequirement from "../Components/PartRequirement/PartRequirement";
import CreatePage from "../Pages/CreatePage/CreatePage";
import EditPage from "../Pages/EditPage/EditPage";
import MyCreatePage from "../Pages/MyCreatePage/MyCreatePage";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            { path: "", element: <HomePage /> },
            { path: "login", element: <LoginPage /> },
            { path: "register", element: <RegisterPage /> },
            { path: "search", element: <ProtectedRoute><SearchPage /></ProtectedRoute> },
            { path: "create-ticket", element: <ProtectedRoute><CreatePage /></ProtectedRoute> },
            { path: "my-create", element: <ProtectedRoute><MyCreatePage /></ProtectedRoute> },
            { path: "ticket/brand/:brand", element: <ProtectedRoute><EditPage /></ProtectedRoute> },
            {
                path: "ticket/:ticker",
                element: <TicketPage />,
                children: [
                    { path: "part-requirement", element: <PartRequirement /> },

                    //{ path: "income-statement", element: <HomePage /> },
                ],
            },
        ],
    },
]);