import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import { Layout } from './Components/Layout';
import { ViewPeople } from './Components/ViewPeople';

function App() {
    return (
        <Layout>
            <Router>
                <Routes>
                <Route exact path='/' element={<ViewPeople/>} />
                </Routes>
            </Router>
      </Layout>
  );
}

export default App;