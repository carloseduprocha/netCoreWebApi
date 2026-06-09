import { BrowserRouter, Routes, Route } from "react-router-dom";
import Lista from './pages/Lista'
import Editar from './pages/Editar'
import Incluir from './pages/Incluir'

export default function RouteApp() {
    return (
        
        <BrowserRouter>
        <Routes>
            <Route path="/" element={<Lista />} />
            <Route path="/editar/:id" element={<Editar />} />
            <Route path="/adicionar" element={<Incluir />} />
        </Routes>
        </BrowserRouter>
       
    )
}