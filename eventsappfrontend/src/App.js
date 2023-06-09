import './App.css';
import Event from './components/Event';
import ParticipationForm from './components/ParticipationForm';
import EventForm from './components/EventForm';
import LoginForm from './components/LoginForm';
import { Routes, Route } from 'react-router-dom';


function App() {
  return (
      <div>
          <Event />
          <Routes>
              <Route path="/" />
              <Route path="/admin" element={<EventForm />} />
              <Route path="/login" element={<LoginForm />} />
              <Route path="/signUp/:id" element={<ParticipationForm />} >              
              </Route>
          </Routes>
      </div>

  );
}

export default App;
