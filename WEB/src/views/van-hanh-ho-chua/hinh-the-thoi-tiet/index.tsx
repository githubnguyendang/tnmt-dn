//React Imports
//React Imports
import React, { SyntheticEvent } from 'react'
import { useState } from 'react'
import { Box, Tab } from '@mui/material'
import Grid from '@mui/material/Unstable_Grid2'
import { TabContext, TabList, TabPanel } from '@mui/lab'
import HinhTheThoiTietGayMuaTraKhuc from './hinh-the-tra-khuc'
import HinhTheThoiTietGayMuaSongVe from './hinh-the-song-ve'
import HinhTheThoiTietGayMuaTraBong from './hinh-the-tra-bong'
import HinhTheThoiTietGayMuaTraCau from './hinh-the-tra-cau'

const HinhTheThoiTietGayMua = () => {
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
              <Tab label='Sông Trà Khúc ' value='1' />
              <Tab label='Sông Vệ ' value='2' />
              <Tab label='Sông Trà Bồng ' value='3' />
              <Tab label='Sông Trà Câu ' value='4' />
            </TabList>
          </Box>

          <TabPanel value='1'>
            <HinhTheThoiTietGayMuaTraKhuc />
          </TabPanel>

          <TabPanel value='2'>
            <HinhTheThoiTietGayMuaSongVe />
          </TabPanel>
          
          <TabPanel value='3'>
            <HinhTheThoiTietGayMuaTraBong />
          </TabPanel>
          
          <TabPanel value='4'>
            <HinhTheThoiTietGayMuaTraCau />
          </TabPanel>
        </TabContext>
      </Grid>
    </Grid>
  )
}

export default HinhTheThoiTietGayMua
