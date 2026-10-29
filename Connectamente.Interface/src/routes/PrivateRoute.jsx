import { useContext } from "react";
import { Navigate, Outlet } from "react-router-dom"; // Importe o Outlet aqui
import { AuthContext } from "../context/AuthContext";

function PrivateRoute({ perfilPermitido }) { // Não precisa mais do children aqui
   const { usuario } = useContext(AuthContext);

   // Se não estiver logado
   if (!usuario) {
     return <Navigate to="/login" replace />;
   }

   if (perfilPermitido && usuario.perfil !== perfilPermitido) {
     return <Navigate to="/login" replace />;
   }

   // IMPORTANTE: Use o Outlet para renderizar as rotas filhas (ProfessorRoutes)
   return <Outlet />; 
}

export default PrivateRoute;