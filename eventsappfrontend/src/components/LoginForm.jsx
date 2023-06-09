import React from 'react';
import axios from "axios";
import { useState } from "react";
import { useNavigate } from 'react-router-dom';


function LoginForm() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();

    async function save(event) {

        event.preventDefault();
        try {
            let code = await axios.post("http://localhost:5173/api/Validation", {

                email: email,
                password: password,

            });
            if (code.status === 200) {
                alert("Welcome Admin");
                navigate('/admin/');
            }
            
        } catch (err) {
            alert(err);
        }
    }
  return (
      <div align="center">
          <div class="row justify-content-center main-row">
              <h1>Login</h1>
              <form>
                  <table>
                      <tbody>
                          <tr>
                              <td><label>Email</label></td>
                              <td>
                                  <input
                                      type="text"
                                      class="form-control"
                                      id="email"
                                      value={email}
                                      onChange={(event) => {
                                          setEmail(event.target.value);
                                      }}
                                  />
                              </td>
                          </tr>
                          <tr>
                              <td><label>Password</label></td>
                              <td>
                                  <input
                                      type="password"
                                      class="form-control"
                                      id="password"
                                      value={password}
                                      onChange={(event) => {
                                          setPassword(event.target.value);
                                      }}
                                  />
                              </td>
                          </tr>
                      </tbody>

                  </table>

                  <div>
                      <button class="btn btn-primary mt-4" onClick={save}>
                          Submit
                      </button>
                  </div>
              </form>
          </div>
      </div>
  );
}

export default LoginForm;