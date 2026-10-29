
function PacientesTable({ pacientes }) {
  if (pacientes.length === 0) {
    return <p>Nenhum paciente encontrado.</p>
  }

  return (
    <table>
      <thead>
        <tr>
          <th>Nome</th>
          <th>E-mail</th>
          <th>Ações</th>
        </tr>
      </thead>

      <tbody>
        {pacientes.map((paciente) => (
          <tr key={paciente.id}>
            <td>{paciente.nome}</td>
            <td>{paciente.email}</td>
            <td>
              {/* Adicionar ações de visualizar e editar */}
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  )
}

export default PacientesTable
