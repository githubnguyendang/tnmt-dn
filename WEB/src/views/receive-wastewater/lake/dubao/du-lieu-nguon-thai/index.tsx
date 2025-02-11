//React Imports

import React, { SyntheticEvent } from 'react'
import { useState } from 'react'
import NguonThaiDiemDB from './NguonThaiDiem'
import NguonThaiSinhHoatDB from './NguonThaiDien_SinhHoat'
import NguonThaiDien_Lon from './NguonThaiDien_Lon'
import NguonThaiDien_GiaCam from './NguonThaiDien_GiaCam'
import NguonThaiDien_TrongLua from './NguonThaiDien_TrongLua'
import NguonThaiDien_TrongCayLauNam from './NguonThaiDien_TrongCayLauNam'
import NguonThaiDien_TrongRung from './NguonThaiDien_TrongRung'
import { Box, Tab } from '@mui/material'
import Grid from '@mui/material/Unstable_Grid2'

import { TabContext, TabList, TabPanel } from '@mui/lab'
import NguonThaiThuySan from './NguonThaiDien_ThuySan'
import NguonThaiTrauBoDB from './NguonThaiDien_Trau'

// eslint-disable-next-line react-hooks/rules-of-hooks
const NguonThaiCLNDB = () => {
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
              <Tab label='NGUỒN THẢI ĐIỂM ' value='1' />
              <Tab label='NGUỒN SINH HOẠT' value='2' />
              <Tab label='NGUỒN GIA SÚC ' value='3' />
              <Tab label='NGUỒN LỢN, GIA SÚC KHÁC ' value='4' />
              <Tab label='NGUỒN GIA CẦM ' value='5' />
              <Tab label='NGUỒN TRỒNG LÚA ' value='6' />
              <Tab label='NGUỒN TRỒNG CÂY' value='7' />
              <Tab label='NGUỒN TRỒNG RỪNG ' value='8' />
              <Tab label='NGUỒN Thủy Sản ' value='9' />
            </TabList>
          </Box>

          <TabPanel value='1'>
            <NguonThaiDiemDB />
          </TabPanel>
          <TabPanel value='2'>
            <NguonThaiSinhHoatDB />
          </TabPanel>

          <TabPanel value='3'>
            <NguonThaiTrauBoDB />
          </TabPanel>

          <TabPanel value='4'>
            <NguonThaiDien_Lon />
          </TabPanel>

          <TabPanel value='5'>
            <NguonThaiDien_GiaCam />
          </TabPanel>

          <TabPanel value='6'>
            <NguonThaiDien_TrongLua />
          </TabPanel>

          <TabPanel value='7'>
            <NguonThaiDien_TrongCayLauNam />
          </TabPanel>

          <TabPanel value='8'>
            <NguonThaiDien_TrongRung />
          </TabPanel>
          <TabPanel value='9'>
            <NguonThaiThuySan />
          </TabPanel>
        </TabContext>
      </Grid>
    </Grid>
  )
}

export default NguonThaiCLNDB
