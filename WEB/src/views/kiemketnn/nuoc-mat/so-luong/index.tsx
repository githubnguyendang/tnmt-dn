import { TabContext, TabList, TabPanel } from '@mui/lab'
import { Box, Tab } from '@mui/material'
import { SyntheticEvent, useState } from 'react'

import RiverQuantity from './River'
import Hothuydien from './hothuydien'
import Hothuyloi from './hothuyloi'
import AoHoDam from './AoDam'

const SoLuongNuocMat = () => {
  const [value, setValue] = useState('1')

  const handleChange = (event: SyntheticEvent, newValue: string) => {
    setValue(newValue)
  }

  return (
    <TabContext value={value}>
      <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
        <TabList onChange={handleChange} aria-label='ground water reserve'>
          <Tab label='Sông, suối' value='1' />
          <Tab label='Hồ thủy điện' value='2' />
          <Tab label='Hồ thủy lợi' value='3' />
          <Tab label='Ao,hồ,đầm,phá' value='4' />
        </TabList>
      </Box>
      <TabPanel value='1'>
        <RiverQuantity />
      </TabPanel>
      <TabPanel value='2'>
        <Hothuydien />
      </TabPanel>
      <TabPanel value='3'>
        <Hothuyloi />
      </TabPanel>
      <TabPanel value='4'>
        <AoHoDam />
      </TabPanel>
    </TabContext>
  )
}
export default SoLuongNuocMat
