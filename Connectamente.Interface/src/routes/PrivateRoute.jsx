import { useContext } from "react";
import { Navigate, Outlet } from "react-router-dom"; // Importe o Outlet aqui
import { AuthContext } from "../context/AuthContext";

function PrivateRoute({ tipoPermitido }) { // Não precisa mais do children aqui
   const { usuario } = useContext(AuthContext);

   // Se não estiver logado
   if (!usuario) {
     return <Navigate to="/login" replace />;
   }

   // Se tiver tipo permitido e for diferente
   if (tipoPermitido && usuario.tipo !== tipoPermitido) {
     return <Navigate to="/login" replace />;
   }

   // IMPORTANTE: Use o Outlet para renderizar as rotas filhas (CoordenadorRoutes)
   return <Outlet />; 
}

export default PrivateRoute;