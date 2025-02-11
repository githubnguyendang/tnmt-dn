import { Box, Tab, Typography } from '@mui/material'
import { useTheme } from '@mui/material/styles'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import { TabContext, TabList, TabPanel } from '@mui/lab'
import { useState } from 'react'
import ReactApexcharts from 'src/@core/components/react-apexcharts'
import { ApexOptions } from 'apexcharts'
import DialogsControlFullScreen from 'src/@core/components/dialog-control-full-screen'

const Detail = () => {
  const getLabelWithDate = (hour: number) => {
    const today = new Date()
    const date = today
    if (hour < 7) {
      date.setDate(today.getDate() + 1)
    }
    const day = date.getDate().toString().padStart(2, '0')
    const month = (date.getMonth() + 1).toString().padStart(2, '0')

    return (
      <Box>
        {hour}h <br /> ({day}/{month})
      </Box>
    )
  }

  const data: any = []
  const loading = false

  const columnsTableDetail: TableColumn[] = [
    {
      id: '#',
      label: 'Lượng mưa (mm)',
      align: 'left',
      children: [
        { id: '7h', label: getLabelWithDate(7), align: 'center' },
        { id: '8h', label: getLabelWithDate(8), align: 'center' },
        { id: '9h', label: getLabelWithDate(9), align: 'center' },
        { id: '10h', label: getLabelWithDate(10), align: 'center' },
        { id: '11h', label: getLabelWithDate(11), align: 'center' },
        { id: '12h', label: getLabelWithDate(12), align: 'center' },
        { id: '13h', label: getLabelWithDate(13), align: 'center' },
        { id: '14h', label: getLabelWithDate(14), align: 'center' },
        { id: '15h', label: getLabelWithDate(15), align: 'center' },
        { id: '16h', label: getLabelWithDate(16), align: 'center' },
        { id: '17h', label: getLabelWithDate(17), align: 'center' },
        { id: '18h', label: getLabelWithDate(18), align: 'center' },
        { id: '19h', label: getLabelWithDate(19), align: 'center' },
        { id: '20h', label: getLabelWithDate(20), align: 'center' },
        { id: '21h', label: getLabelWithDate(21), align: 'center' },
        { id: '22h', label: getLabelWithDate(22), align: 'center' },
        { id: '23h', label: getLabelWithDate(23), align: 'center' },
        { id: '24h', label: getLabelWithDate(24), align: 'center' },
        { id: '1h', label: getLabelWithDate(1), align: 'center' },
        { id: '2h', label: getLabelWithDate(2), align: 'center' },
        { id: '3h', label: getLabelWithDate(3), align: 'center' },
        { id: '4h', label: getLabelWithDate(4), align: 'center' },
        { id: '5h', label: getLabelWithDate(5), align: 'center' },
        { id: '6h', label: getLabelWithDate(6), align: 'center' }
      ]
    }
  ]

  const [tab, setTab] = useState('1')

  const handleChange = (event: React.SyntheticEvent, newValue: string) => {
    setTab(newValue)
  }

  const series = [
    {
      data: [21, 22, 10, 28, 16, 21, 13, 30, 21, 22, 10, 28, 16, 21, 13, 30, 21, 22, 10, 28, 16, 21, 13, 30]
    }
  ]

  const options: ApexOptions = {
    legend: {
      show: true,
      position: 'bottom'
    },
    dataLabels: {
      enabled: true
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: '50%'
      }
    },
    chart: {
      type: 'bar',
      height: 444,
      width: '100%'
    },
    stroke: {
      show: true,
      width: 2,
      colors: ['transparent']
    },
    fill: {
      opacity: 1
    }
  }

  return (
    <Box sx={{ width: '100%', typography: 'body1' }}>
      <TabContext value={tab}>
        <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
          <TabList onChange={handleChange} aria-label='lab API tabs example'>
            <Tab label='Số liệu' value='1' />
            <Tab label='Biểu đồ' value='2' />
          </TabList>
        </Box>
        <TabPanel value='1'>
          <TableComponent
            id='luongmuahientai'
            columns={columnsTableDetail}
            rows={data}
            loading={loading}
            pagination
            actions={() => <Box></Box>}
          />
        </TabPanel>
        <TabPanel value='2'>
          <Box width={1000}>
            <ReactApexcharts options={options} series={series} type='bar' />
          </Box>
        </TabPanel>
      </TabContext>
    </Box>
  )
}

const ViewDetail = (station: string) => {
  const theme = useTheme()

  return (
    <DialogsControlFullScreen>
      {(openDialogs: (content: React.ReactNode, title: React.ReactNode) => void) => (
        <Box>
          <Typography
            variant='caption'
            sx={{ cursor: 'pointer' }}
            color={theme.palette.primary.dark}
            onClick={() => openDialogs(<Detail />, station)}>
            {station}
          </Typography>
        </Box>
      )}
    </DialogsControlFullScreen>
  )
}
export default ViewDetail
