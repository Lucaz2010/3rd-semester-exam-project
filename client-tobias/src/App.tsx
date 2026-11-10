import { APITester } from "./APITester";
import {useState} from "react";
import {AdminPage} from "@/AdminPage.tsx";
import {BrowserRouter, Routes, Route, useLocation, useNavigate, Navigate} from "react-router-dom";




export function App() {




    return (
        <BrowserRouter>
                <AppLayout />
        </BrowserRouter>
    );
}

function AppLayout() {
    const navigate = useNavigate();
    const location = useLocation();

    function handleLogout() {
        navigate("/login");
    }

    const isLoginPage =
        location.pathname === "/login" ||
        location.pathname === "/";

    return (
        <>
            {!isLoginPage && (
                <div className="Header">
                    <h1 className="WebsiteNameText">
                        Business Esbjerg
                    </h1>

                    <button
                        className="LoggedInText"
                        onClick={handleLogout}
                    >
                        Log out
                    </button>
                </div>
            )}

            <Routes>
                
                
                
                <Route path="/adminpage" element={
                            <AdminPage />
                    }
                />

                <Route
                    path="*"
                    element={<Navigate to="/login" replace />}
                />
            </Routes>
        </>
    );
}

export default App;
