import {useEffect, useState} from "react";
import { api } from "@/api/Api.ts"
import type {HolidayRequest} from "@/api/Api.ts";
import "./index.css";


export function HolidayApproval() {
    const [holidayRequests, setHolidayRequests] = useState<HolidayRequest[]>([])

    useEffect(() => {
        api.getHolidayRequests.userQueriesGetHolidayRequests()
            .then((r: HolidayRequest[]) => {
                setHolidayRequests(r);
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
                        Employee
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

                    {holidayRequests.map((h) => (

                        <tbody>
                        <tr>
                            <td className="UsersTableDesignTh">{h.user?.name}</td>
                            <td className="UsersTableDesignTh">{h.startDate} - {h.endDate}</td>
                            <td className="UsersTableDesignTh">{h.requestedDays}</td>
                            <td className="UsersTableDesignTh">{h.startDate}</td>


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