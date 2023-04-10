import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { createRoot } from 'react-dom/client';
import FileInput from './components/FileInput.jsx';
import NavigationBar from './components/NavigationBar.jsx';
import HomeDescription from './components/HomePageDescription.jsx';

function App() {
    return(
        <>
            <NavigationBar />
            <HomeDescription />
            <FileInput />
        </>
    )
}

createRoot(document.getElementById('root')).render(<App />);