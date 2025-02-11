import React, { useState } from 'react'
import Checkbox from '@mui/material/Checkbox'
import FormControlLabel from '@mui/material/FormControlLabel'
import { FormControl, FormGroup, Typography } from '@mui/material'

const MapLegendThaiDiem = ({ onChange }: { onChange: (selectedOptions: string[]) => void }) => {
  console.log(onChange);
  
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
          label={
            <Typography variant='overline' sx={{ fontWeight: 'bold', display: 'flex', alignItems: 'center' }}>
              <span>&nbsp;Khu công nghiệp</span>
            </Typography>
          }
        />
         <FormControlLabel
          control={<Checkbox checked={selectedOptions.includes('CCN')} onChange={handleOptionChange} value='CCN' />}
          label={
            <Typography variant='overline' sx={{ fontWeight: 'bold', display: 'flex', alignItems: 'center' }}>
              <img src='/images/icon/cumcn.png' alt='icon' width={20} />
              <span>&nbsp;Cụm Công Nghiệp</span>
            </Typography>
          }
        />
         <FormControlLabel
          control={<Checkbox checked={selectedOptions.includes('Thuydien')} onChange={handleOptionChange} value='Thuydien' />}
          label={
            <Typography variant='overline' sx={{ fontWeight: 'bold', display: 'flex', alignItems: 'center' }}>
              <img src='/images/icon/thuydien.png' alt='icon' width={20} />
              <span>&nbsp;Thủy điện</span>
            </Typography>
          }
        />
        <FormControlLabel
          control={<Checkbox checked={selectedOptions.includes('yte')} onChange={handleOptionChange} value='yte' />}
          label={
            <Typography variant='overline' sx={{ fontWeight: 'bold', display: 'flex', alignItems: 'center' }}>
              <img src='/images/icon/cs_benhvien.png' alt='icon' width={20} />
              <span>&nbsp;Y tế</span>
            </Typography>
          }
        />
        <FormControlLabel
          control={<Checkbox checked={selectedOptions.includes('cang')} onChange={handleOptionChange} value='cang' />}
          label={
            <Typography variant='overline' sx={{ fontWeight: 'bold', display: 'flex', alignItems: 'center' }}>
              <img src='/images/icon/cang.png' alt='icon' width={20} />
              <span>&nbsp;Cảng</span>
            </Typography>
          }
        />
        <FormControlLabel
          control={<Checkbox checked={selectedOptions.includes('Congty')} onChange={handleOptionChange} value='Congty' />}
          label={
            <Typography variant='overline' sx={{ fontWeight: 'bold', display: 'flex', alignItems: 'center' }}>
              <img src='/images/icon/congty.png' alt='icon' width={20} />
              <span>&nbsp;Công ty</span>
            </Typography>
          }
        />
         <FormControlLabel
          control={<Checkbox checked={selectedOptions.includes('khachsan')} onChange={handleOptionChange} value='khachsan' />}
          label={
            <Typography variant='overline' sx={{ fontWeight: 'bold', display: 'flex', alignItems: 'center' }}>
              <img src='/images/icon/khachsan.png' alt='icon' width={20} />
              <span>&nbsp;Khách sạn</span>
            </Typography>
          }
        />
         <FormControlLabel
          control={<Checkbox checked={selectedOptions.includes('tttm')} onChange={handleOptionChange} value='tttm' />}
          label={
            <Typography variant='overline' sx={{ fontWeight: 'bold', display: 'flex', alignItems: 'center' }}>
              <img src='/images/icon/tttm.png' alt='icon' width={20} />
              <span>&nbsp;Trung tâm thương mại</span>
            </Typography>
          }

        />
         <FormControlLabel
          control={<Checkbox checked={selectedOptions.includes('khudancu')} onChange={handleOptionChange} value='khudancu' />}
          label={
            <Typography variant='overline' sx={{ fontWeight: 'bold', display: 'flex', alignItems: 'center' }}>
              <img src='/images/icon/khudancu.png' alt='icon' width={20} />
              <span>&nbsp;Khu dân cư</span>
            </Typography>
          }
        />
      </FormGroup>
    </FormControl>
  )
}

export default MapLegendThaiDiem
