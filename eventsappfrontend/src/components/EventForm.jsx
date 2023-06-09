import React from 'react';
import axios from "axios";
import { useState } from "react";

function EventForm() {

    const [evName, setName] = useState("");
    const [date, setDate] = useState("");
    const [count, setCount] = useState(1);

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

            window.location.reload(false);
        } catch (err) {
            alert(err);
        }
    }
    return (
      <div align="center">
        <div class="row justify-content-center main-row">
          <h1>Create Event</h1>
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
                                            min="1"
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
        </div>
            );
}

export default EventForm;