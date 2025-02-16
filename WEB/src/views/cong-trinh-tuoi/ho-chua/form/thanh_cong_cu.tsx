import React from 'react'
import { Box, TextField, Button } from '@mui/material'
import { LocalizationProvider } from '@mui/x-date-pickers'
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import dayjs from 'dayjs'

interface FilterToolbarProps {
  startDate: dayjs.Dayjs | null
  endDate: dayjs.Dayjs | null
  setStartDate: (date: dayjs.Dayjs | null) => void
  setEndDate: (date: dayjs.Dayjs | null) => void
  onFilter: () => void
}

const FilterToolbar: React.FC<FilterToolbarProps> = ({
  startDate,
  endDate,
  setStartDate,
  setEndDate,
  onFilter
}) => {
  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <Box display="flex" alignItems="center" mb={2}>
        <TextField
          label="Start Date"
          type="date"
          value={startDate ? startDate.format('YYYY-MM-DD') : ''}
          onChange={(e) => setStartDate(dayjs(e.target.value))}
          InputLabelProps={{
            shrink: true,
          }}
          sx={{ mr: 2 }}
        />
        <TextField
          label="End Date"
          type="date"
          value={endDate ? endDate.format('YYYY-MM-DD') : ''}
          onChange={(e) => setEndDate(dayjs(e.target.value))}
          InputLabelProps={{
            shrink: true,
          }}
          sx={{ mr: 2 }}
        />
        <Button variant="contained" color="primary" onClick={onFilter}>
          Lọc
        </Button>
      </Box>
    </LocalizationProvider>
  )
}

export default FilterToolbar
