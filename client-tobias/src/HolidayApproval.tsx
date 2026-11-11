import {useEffect, useState} from "react";
import { api } from "@/api/Api.ts"
import type {Admin, User} from "@/api/Api.ts";
import "./index.css";


export function HolidayApproval() {
    const [user, setUsers] = useState<User[]>([])

    useEffect(() => {
        api.getAllUsers.userQueriesGetAllUsers()
            .then((r: User[]) => {
                setUsers(r);
            })

    }, []);
    
    
    
    return (
        <>
            <h2>Admin page for approving/declining holiday requests </h2>

            <div className="UsersTableDesign">
                <h2 className="TableHeader">Manage holiday requests</h2>

                <table className="Table">
                    <thead>
                    <th className="UsersTableDesignTh">
                        Username
                    </th>
                    <th className="UsersTableDesignTh">
                        Holiday period requested
                    </th>
                    <th className="UsersTableDesignTh">
                        Total days
                    </th>
                    
                    <th className="UsersTableDesignTh">
                        Requested on</th>

                    <th className="UsersTableDesignTh">
                        Approve/decline
                    </th>

                    </thead>

                    {user.map((u) => (

                        <tbody>
                        <tr>
                            <td className="UsersTableDesignTh">Employee</td>
                            <td className="UsersTableDesignTh">Holiday days requested</td>
                            <td className="UsersTableDesignTh">Total days</td>
                            <td className="UsersTableDesignTh">Requested on</td>


                            <td className="UsersTableDesignTh">
                                <button className="EditUserButton" onClick={() => {
                                    
                                }}>Approve</button>

                                <button className="DeleteUserButton" onClick={() => {

                                }}>Decline</button>
                                
                                
                            </td>
                           
                        </tr>

                        </tbody>
                    ))}
                </table>

            </div>



        </>
    )
    
}