import { TabContext, TabList, TabPanel } from '@mui/lab'
import { Box, Tab } from '@mui/material'
import { SyntheticEvent, useState } from 'react'
import LVSlientinh from './LVS-lientinh'
import LVSnoitinh from './LVS-noitinh'
import TramThuyVan from './Tram-thuy-van'
import Chuyennuocluuvuc from './chuyen-nuoc-luu-vuc'

const TotalSFWater = () => {
  const [value, setValue] = useState('1')

  const handleChange = (event: SyntheticEvent, newValue: string) => {
    setValue(newValue)
  }

  return (
    <TabContext value={value}>
      <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
        <TabList onChange={handleChange} aria-label='ground water reserve'>
          <Tab label='Q-(LVS liên tỉnh)' value='1' />
          <Tab label='Q-(LVS nội tỉnh)' value='2' />
          <Tab label='Q-(Trạm TV)' value='3' />
          <Tab label='Q (Chuyển nước giữa các LVS)' value='4' />
        </TabList>
      </Box>
      <TabPanel value='1'>
        <LVSlientinh />
      </TabPanel>
      <TabPanel value='2'>
        <LVSnoitinh />
      </TabPanel>
      <TabPanel value='3'>
        <TramThuyVan />
      </TabPanel>
      <TabPanel value='4'>
      <Chuyennuocluuvuc/>
      </TabPanel>
    </TabContext>
  )
}
export default TotalSFWater
