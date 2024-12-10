import './index.css'
import { searchTickets } from './api.tsx'
import "tailwindcss/tailwind.css";
import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App.tsx';
import { RouterProvider } from 'react-router-dom';
import { router } from './Routes/Routes';

ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
    <RouterProvider router={router} />
    </React.StrictMode>
);
