import axios from "axios";
import { useEffect, useState } from "react";
import { useNavigate } from 'react-router-dom';

function Event() {
    const [events, setEvents] = useState([]);
    const navigate = useNavigate();


    useEffect(() => {
        (async () => await Load())();
    }, []);
    async function Load() {

        const result = await axios.get("http://localhost:5173/api/Event");
        setEvents(result.data);
    }

    function navigateToSignUpForm(id)  {
        navigate('/signUp/' + id);
    };

    function navigateToLogin() {
        navigate('/login/');
    };

    return (
        <div>
            <div align="right">
                <button class="btn btn-primary mt-4" onClick={navigateToLogin}>
                    Login
                </button>
            </div>
            <div align="center">
               <br/>
                <h1>Events</h1>
                <table class="table table-dark" align="center">
                    <thead>
                        <tr>
                            <th scope="col">Name</th>
                            <th scope="col">Date</th>
                            <th scope="col">Count</th>

                            <th scope="col">Option</th>
                        </tr>
                    </thead>
                    {events.map(function fn(ev) {
                        return (
                            <tbody>
                                <tr>
                                    <td>{ev.name}</td>
                                    <td>{ev.date}</td>
                                    <td>{ev.count}</td>

                                    <td>
                                        <button class="btn btn-light" onClick={() => navigateToSignUpForm(ev.id)}>Sign Up</button>
                                    </td>
                                </tr>
                            </tbody>
                        );
                    })}
                </table>
            </div>
        </div>
        );
}

export default Event;
