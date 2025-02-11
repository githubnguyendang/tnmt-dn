import { TableCell, TableRow, TableBody } from '@mui/material'
import { Data, TableColumn } from '.'
import React from 'react'

function renderTableCell(
  column: TableColumn,
  row: any,
  rowIndex: number,
  colIndex: number,
  currentPage: number,
  rowsPerPage: number,
  actions: ((row: Data) => React.ReactNode) | null
) {
  // Recursive rendering of columns
  const renderCellContent = (currentColumn: any, rowData: any, key: any) => {
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

    const tableCellStyles = {
      py: 0,
      minWidth: currentColumn.minWidth,
      fontSize: '13px',
      border: '1px solid #dee2e6',
      whiteSpace: 'nowrap' as const,
      ...(currentColumn.pinned === 'left' ? startColStyles : currentColumn.pinned === 'right' ? endColStyles : {}),
      ...(currentColumn.pinned ? stickyColStyles : {})
    }

    if (currentColumn.children) {
      return currentColumn.children.map((childColumn: any, childIndex: any) =>
        renderTableCell(childColumn, rowData, rowIndex, childIndex, currentPage, rowsPerPage, actions)
      )
    } else {
      return (
        <TableCell
          sx={{
            ...tableCellStyles
          }}
          key={key}
          align={currentColumn.align}
          size='small'>
          {currentColumn.id === 'actions' ? (
            actions && actions(rowData)
          ) : currentColumn.id === 'stt' ? (
            currentPage * rowsPerPage + rowIndex + 1
          ) : typeof currentColumn.elm === 'function' ? (
            currentColumn.elm(rowData)
          ) : currentColumn.format ? (
            currentColumn.format(rowData[currentColumn.id])
          ) : rowData['id'] !== -1 ? (
            rowData[currentColumn.id]
          ) : (
            <span style={{ fontWeight: 700 }}>{rowData[currentColumn.id]}</span>
          )}
        </TableCell>
      )
    }
  }

  return renderCellContent(column, row, `${colIndex}-${rowIndex}`)
}

function renderTableBody(
  columns: TableColumn[],
  data: any,
  actions: ((row: Data) => React.ReactNode) | null,
  page: number,
  rowsPerPage: number
) {
  return (
    <TableBody>
      {data?.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage).map((dataItem: any, rowIndex: any) => (
        <TableRow key={rowIndex}>
          {columns.map((column, colIndex) =>
            renderTableCell(column, dataItem, rowIndex, colIndex, page, rowsPerPage, actions)
          )}
        </TableRow>
      ))}
    </TableBody>
  )
}

export default renderTableBody
