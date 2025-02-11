import { TabContext, TabList, TabPanel } from '@mui/lab'
import { Box, Tab } from '@mui/material'
import { SyntheticEvent, useState } from 'react'
import MNNTRiver from './song-suoi/River'
import MNNTLake from './ao-ho/Lake'

const CategoryMNNT = () => {
  const [value, setValue] = useState('1')

  const handleChange = (event: SyntheticEvent, newValue: string) => {
    setValue(newValue)
  }

  return (
    <TabContext value={value}>
      <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
        <TabList onChange={handleChange} aria-label='ground water reserve'>
          <Tab label='Sông,suối nội tỉnh ' value='1' />
          <Tab label='Hồ thủy lợi' value='2' />
          <Tab label='Hồ thủy điện' value='3' />
        </TabList>
      </Box>
      <TabPanel value='1'>
        <MNNTRiver />
      </TabPanel>
      <TabPanel value='2'>
        <MNNTLake />
      </TabPanel>
      <TabPanel value='3'>
        <MNNTLake />
      </TabPanel>
    </TabContext>
  )
}
export default CategoryMNNT
