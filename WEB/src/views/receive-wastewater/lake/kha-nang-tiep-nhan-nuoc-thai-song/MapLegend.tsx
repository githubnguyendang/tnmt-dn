import React, { useState } from 'react'
import Checkbox from '@mui/material/Checkbox'
import FormControlLabel from '@mui/material/FormControlLabel'
import { FormControl, FormGroup, FormLabel } from '@mui/material'

const MapLegendWaste = ({ onChange }: any) => {
  const [selectedOptions, setSelectedOptions] = useState<string[]>([])

  const handleOptionChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value
    const isChecked = event.target.checked

    if (isChecked) {
      setSelectedOptions([value])
      onChange([value])
    } else {
      setSelectedOptions([])
      onChange([])
    }
  }

  return (
    <FormControl component='fieldset'>
      <FormLabel component='legend'>Chỉ số chất lượng nước thải</FormLabel>
      <FormGroup>
        <FormControlLabel
          control={
            <Checkbox checked={selectedOptions.includes('ltnBod')} onChange={handleOptionChange} value='ltnBod' />
          }
          label='BOD'
        />
        <FormControlLabel
          control={
            <Checkbox checked={selectedOptions.includes('ltnCod')} onChange={handleOptionChange} value='ltnCod' />
          }
          label='COD'
        />
        <FormControlLabel
          control={
            <Checkbox checked={selectedOptions.includes('ltnAmoni')} onChange={handleOptionChange} value='ltnAmoni' />
          }
          label='Amoni'
        />
        <FormControlLabel
          control={
            <Checkbox checked={selectedOptions.includes('ltnTongN')} onChange={handleOptionChange} value='ltnTongN' />
          }
          label='Tổng N'
        />
        <FormControlLabel
          control={
            <Checkbox checked={selectedOptions.includes('ltnTongP')} onChange={handleOptionChange} value='ltnTongP' />
          }
          label='Tổng P'
        />
        <FormControlLabel
          control={
            <Checkbox checked={selectedOptions.includes('ltnTSS')} onChange={handleOptionChange} value='ltnTSS' />
          }
          label='TSS'
        />
        <FormControlLabel
          control={
            <Checkbox
              checked={selectedOptions.includes('ltnColiform')}
              onChange={handleOptionChange}
              value='ltnColiform'
            />
          }
          label='Coliform'
        />
      </FormGroup>
    </FormControl>
  )
}

export default MapLegendWaste
