import { Box, Tab } from '@mui/material'
import Grid from '@mui/material/Unstable_Grid2'
import { TabContext, TabList, TabPanel } from '@mui/lab'
import { SyntheticEvent, useState } from 'react'
import React from 'react'
import KQCLNuocMat from './KQCLNuocMat'
import WasteWaterDetails from './wastewaterDetails'

// eslint-disable-next-line react-hooks/rules-of-hooks
const NguonNuocNhanDB = () => {
  const [value, setValue] = useState('1')

  const handleChange = (event: SyntheticEvent, newValue: string) => {
    setValue(newValue)
  }

  return (
    <Grid container spacing={2}>
      <Grid xs={12} md={12}>
        <TabContext value={value}>
          <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
            <TabList onChange={handleChange} aria-label='ground water reserve'>
              <Tab label='KQCL Nước mặt' value='1' />
              <Tab label='Dữ liệu nguồn nước nhận' value='2' />
            </TabList>
          </Box>

          <TabPanel value='1'>
            <KQCLNuocMat />
          </TabPanel>
          <TabPanel value='2'>
            <WasteWaterDetails />
          </TabPanel>
        </TabContext>
      </Grid>
    </Grid>
  )
}

export default NguonNuocNhanDB
