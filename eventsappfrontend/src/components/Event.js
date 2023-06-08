import axios from "axios";
import { useEffect, useState } from "react";
import { useNavigate } from 'react-router-dom';



function Event() {

    const [evName, setName] = useState("");
    const [date, setDate] = useState("");
    const [count, setCount] = useState(1);
    const [events, setEvents] = useState([]);
    const navigate = useNavigate();


    useEffect(() => {
        (async () => await Load())();
    }, []);
    async function Load() {

        const result = await axios.get("http://localhost:5173/api/Event");
        setEvents(result.data);
        console.log(result.data);
    }
    async function save(event) {

        event.preventDefault();
        try {
            await axios.post("http://localhost:5173/api/Event", {

                name: evName,
                date: date,
                count: count,

            });
            alert("Event created Successfully");
            setName("");
            setDate("");
            setCount(1);


            Load();
        } catch (err) {
            alert(err);
        }
    }

    const navigateToSignUpForm = (id) => {
        console.log("navigating/"+id);
        navigate('/signUp/' + id, { replace: true });
    };
        return (
            <div align="center">
                <h1>Event Details</h1>
                <div class="row justify-content-center main-row">
                    <form>
                        <table>
                            <tbody>
                                <tr>
                                    <td><label>Event Name</label></td>
                                    <td>
                                        <input
                                            type="text"
                                            class="form-control"
                                            id="evName"
                                            value={evName}
                                            onChange={(event) => {
                                                setName(event.target.value);
                                            }}
                                                />
                                    </td>
                                </tr>
                                <tr>
                                    <td><label>Date</label></td>
                                    <td>
                                        <input
                                            type="text"
                                            class="form-control"
                                            id="date"
                                            value={date}
                                            onChange={(event) => {
                                                setDate(event.target.value);
                                            }}
                                            />
                                    </td>
                                </tr>
                            <tr>
                                <td><label>Participant Count</label></td>
                                    <td>
                                        <input
                                            type="number"
                                            class="form-control"
                                            id="count"
                                            value={count}
                                            onChange={(event) => {
                                                setCount(event.target.value);
                                            }}
                                                    />
                                    </td>
                            </tr>
                            </tbody>
                            
                        </table>
                            
                        <div>
                            <button class="btn btn-primary mt-4" onClick={save}>
                                Create
                            </button>
                        </div>
                    </form>
                </div>
                <br></br>

                <table class="table table-dark" align="center">
                    <thead>
                        <tr>
                            <th scope="col">Id</th>
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
                                    <th scope="row">{ev.id} </th>
                                    <td>{ev.name}</td>
                                    <td>{ev.date}</td>
                                    <td>{ev.count}</td>

                                    <td>
                                        <button class="btn btn-light" onClick={navigateToSignUpForm(ev.id)}>Sign Up</button>
                                    </td>
                                </tr>
                            </tbody>
                        );
                    })}
                </table>

            </div>
        );
}

export default Event;
