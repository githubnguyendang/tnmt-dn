import { TableCell, TableHead, TableRow } from '@mui/material'
import { TableColumn } from '.'

// Calculates the maximum depth of nested columns
const calcMaxDepth = (columns: TableColumn[], depth = 0) => {
  let maxDepth = depth
  columns.forEach(column => {
    if (column.children && column.children.length > 0) {
      const childDepth = calcMaxDepth(column.children, depth + 1)
      maxDepth = Math.max(maxDepth, childDepth)
    }
  })

  return maxDepth
}

const countTotalChildren: any = (column: TableColumn) => {
  // If the column has no children, it's a leaf column, so return 1
  if (!column.children || column.children.length === 0) {
    return 1
  }

  // Count the column's children and their children recursively
  return column.children.reduce((acc, child) => {
    return acc + countTotalChildren(child)
  }, 0)
}

function buildRow(columns: TableColumn[], currentDepth: number, row: TableColumn[], maxDepth: number, parentDepth = 0) {
  columns.forEach(column => {
    if (parentDepth === currentDepth) {
      const colspan = column.children ? countTotalChildren(column) : 1
      const rowspan = column.children && column.children.length > 0 ? 1 : maxDepth - currentDepth + 1

      const cell: TableColumn = {
        id: column.id,
        label: column.label,
        colspan: column.colspan ? column.colspan : colspan,
        rowspan: column.rowspan ? column.rowspan : rowspan,
        align: 'center',
        minWidth: column.minWidth,
        format: column.format,
        elm: column.elm,
        pinned: column.pinned
      }
      row.push(cell)
    }

    if (column.children) {
      buildRow(column.children, currentDepth, row, maxDepth, parentDepth + 1)
    }
  })
}

function renderTableHead(columns: TableColumn[]) {
  const maxDepth = calcMaxDepth(columns)
  const rows = []

  for (let depth = 0; depth <= maxDepth; depth++) {
    const row: TableColumn[] = []
    buildRow(columns, depth, row, maxDepth)
    rows.push(row)
  }

  const stickyColStyles = {
    position: 'sticky' as const,
    background: '#fff',
    zIndex: 1,
    whiteSpace: 'unset' as const
  }

  const startColStyles = {
    left: -1,
    boxShadow: 'rgba(0, 0, 0, 0.45) -10px 0px 20px -20px inset'
  }

  const endColStyles = {
    right: -1,
    boxShadow: 'rgba(0, 0, 0, 0.45) 10px 0px 20px -20px inset'
  }

  const tableHeadCellStyles = {
    backgroundColor: 'rgb(21 83 143)',
    color: '#fff',
    border: '1px solid #fff',
    whiteSpace: 'nowrap' as const
  }

  return (
    <TableHead className='tableHead'>
      {rows.map((row, rowIndex) => (
        <TableRow key={rowIndex}>
          {row.map((cell: TableColumn, cellIndex: any) => (
            <TableCell
              key={cellIndex}
              colSpan={cell.colspan}
              rowSpan={cell.rowspan}
              align={cell.align}
              sx={{
                minWidth: cell.minWidth,
                maxWidth: cell.minWidth,
                width: cell.minWidth,
                zIndex: 2,
                ...(cell.pinned === 'left' ? startColStyles : cell.pinned === 'right' ? endColStyles : {}),
                ...(cell.pinned ? stickyColStyles : {})
              }}
              style={{ ...tableHeadCellStyles }}>
              {cell.id === 'actions' ? (typeof cell.elm === 'function' ? cell.elm() : cell.label) : cell.label}
            </TableCell>
          ))}
        </TableRow>
      ))}
    </TableHead>
  )
}

export default renderTableHead
