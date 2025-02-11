//React Imports
import React, { SyntheticEvent } from 'react'
import { useState } from 'react'
import { Box, Tab } from '@mui/material'
import Grid from '@mui/material/Unstable_Grid2'
import { TabContext, TabList, TabPanel } from '@mui/lab'
import DakdrinhhMuaLu from './dakdinh-mua-lu'
import TomTatVanHanhLuSom from './tom-tat-lu-som'

const VanHanhMuaLuSom = () => {
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
              <Tab label='Tóm tắt vận hành ' value='1' />
              <Tab label='Hồ DakDrink ' value='2' />
              <Tab label='Hồ Nước Trong' value='3' />
              <Tab label='Hồ Sơn Trà 1 ' value='4' />
              <Tab label='Hồ Đăk re ' value='5' />
              <Tab label='Hồ Sơn Tây ' value='6' />
            </TabList>
          </Box>

          <TabPanel value='1'>
            <TomTatVanHanhLuSom />
          </TabPanel>

          <TabPanel value='2'>
            <DakdrinhhMuaLu />
          </TabPanel>

          <TabPanel value='3'>
            <DakdrinhhMuaLu />
          </TabPanel>
        </TabContext>
      </Grid>
    </Grid>
  )
}

export default VanHanhMuaLuSom
