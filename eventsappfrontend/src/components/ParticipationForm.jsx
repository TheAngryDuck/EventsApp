import React from 'react';
import { useEffect, useState } from "react";
import { useParams } from 'react-router-dom';
import axios from "axios";


function ParticipationForm() {
    const { id } = useParams()
    const [firstName, setName] = useState("");
    const [lastName, setLastName] = useState("");
    const [idCode, setCode] = useState("");

    async function save(event) {

        event.preventDefault();
        try {
            const result =  await axios.post("http://localhost:5173/api/Participant", {

                name: firstName,
                lastName: lastName,
                idCode: idCode,
            });
            await axios.post("http://localhost:5173/api/ParticipantInEvent", {

                participantId: result.data,
                eventId: id,
            });
            alert("Signed Up Successfully");
            setName("");
            setLastName("");
            setCode("");

        } catch (err) {
            alert(err);
        }
    }

    return (
        <div align="center">
      <p>Hello world! {id}</p>
      <h1>Sign Up!</h1>
            <div class="row justify-content-center main-row">
                    <form>
                    <table>
                        <tbody>
                                <tr>
                                    <td><label>First Name</label></td>
                                    <td>
                                        <input
                                            type="text"
                                            class="form-control"
                                        id="firstName"
                                        value={firstName}
                                            onChange={(event) => {
                                                setName(event.target.value);
                                            }}
                                                />
                                    </td>
                                </tr>
                                <tr>
                                    <td><label>Last Name</label></td>
                                    <td>
                                        <input
                                            type="text"
                                            class="form-control"
                                        id="lastName"
                                        value={lastName}
                                            onChange={(event) => {
                                                setLastName(event.target.value);
                                            }}
                                            />
                                    </td>
                                </tr>
                            <tr>
                                <td><label>Id Code</label></td>
                                    <td>
                                        <input
                                            type="text"
                                            class="form-control"
                                        id="idCode"
                                        value={idCode}
                                            onChange={(event) => {
                                                setCode(event.target.value);
                                            }}
                                                    />
                                    </td>
                            </tr>
                        </tbody>
                        </table>
                            
                        <div>
                            <button class="btn btn-primary mt-4" onClick={save}>
                                Sign In
                            </button>
                        </div>
                    </form>
            </div>
        </div>

  );
}

export default ParticipationForm;