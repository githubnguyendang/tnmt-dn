import React, { useState } from 'react'
import Checkbox from '@mui/material/Checkbox'
import FormControlLabel from '@mui/material/FormControlLabel'
import { FormControl, FormGroup } from '@mui/material'

const MapLegendThaiDiem = ({ onChange }: { onChange: (selectedOptions: string[]) => void }) => {
  const [selectedOptions, setSelectedOptions] = useState<string[]>([])

  const handleOptionChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value
    const isChecked = event.target.checked

    let updatedSelectedOptions = []
    if (isChecked) {
      updatedSelectedOptions = [...selectedOptions, value]
    } else {
      updatedSelectedOptions = selectedOptions.filter(option => option !== value)
    }

    setSelectedOptions(updatedSelectedOptions)
    onChange(updatedSelectedOptions)
  }

  return (
    <FormControl component='fieldset'>
      <FormGroup>
        <FormControlLabel
          control={
            <Checkbox
              checked={selectedOptions.includes('Khu Công Nghiệp')}
              onChange={handleOptionChange}
              value='Khu Công Nghiệp'
            />
          }
          label='Khu Công Nghiệp'
        />
        <FormControlLabel
          control={
            <Checkbox
              checked={selectedOptions.includes('Cụm Công Nghiệp')}
              onChange={handleOptionChange}
              value='Cụm Công Nghiệp'
            />
          }
          label='Cụm Công Nghiệp'
        />
         <FormControlLabel
          control={<Checkbox checked={selectedOptions.includes('Thuydien')} onChange={handleOptionChange} value='Thuydien' />}
          label='Thủy điện'
        />
        <FormControlLabel
          control={<Checkbox checked={selectedOptions.includes('yte')} onChange={handleOptionChange} value='yte' />}
          label='Y tế'
        />
        <FormControlLabel
          control={<Checkbox checked={selectedOptions.includes('cang')} onChange={handleOptionChange} value='cang' />}
          label='Cảng'
        />
        <FormControlLabel
          control={<Checkbox checked={selectedOptions.includes('congty')} onChange={handleOptionChange} value='congty' />}
          label='Công ty'
        />
         <FormControlLabel
          control={<Checkbox checked={selectedOptions.includes('khachsan')} onChange={handleOptionChange} value='khachsan' />}
          label='Khách sạn'
        />
         <FormControlLabel
          control={<Checkbox checked={selectedOptions.includes('tttm')} onChange={handleOptionChange} value='tttm' />}
          label='TT thương mại'
        />
         <FormControlLabel
          control={<Checkbox checked={selectedOptions.includes('khudancu')} onChange={handleOptionChange} value='khudancu' />}
          label='Khu dân cư'
        />
      </FormGroup>
    </FormControl>
  )
}

export default MapLegendThaiDiem
