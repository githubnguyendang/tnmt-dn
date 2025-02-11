import {
  Box,
  Paper,
  Tab,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TablePagination,
  TableRow,
  Tabs
} from '@mui/material'
import React, { useState, useEffect } from 'react'
import {
  ComposedChart,
  Bar,
  Line,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  Legend,
  ResponsiveContainer,
  ReferenceLine
} from 'recharts'
import { postData } from 'src/api/axios'
import useRainData from './data' // Import the custom hook

interface TabPanelProps {
  children?: React.ReactNode
  index: number
  value: number
}

function CustomTabPanel(props: TabPanelProps) {
  const { children, value, index, ...other } = props

  return (
    <div
      role='tabpanel'
      hidden={value !== index}
      id={`simple-tabpanel-${index}`}
      aria-labelledby={`simple-tab-${index}`}
      {...other}>
      {value === index && <Box sx={{ p: 3 }}>{children}</Box>}
    </div>
  )
}

function a11yProps(index: number) {
  return {
    id: `simple-tab-${index}`,
    'aria-controls': `simple-tabpanel-${index}`
  }
}

const HoDakdrinhPage = () => {
  const [forecastData, setForecastData] = useState<any[]>([])
  const { xDakTo, xQuangNgai, dateTime } = useRainData() // Call the custom hook
  // const xQuangNgai22to25 = [
  //   0, 58, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 25.1, 0, 0, 0, 0, 0, 10, 0, 0, 0, 0, 0, 20, 0, 0, 0, 0, 0,
  //   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
  //   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
  // ]

  // const xDakTo22to25 = [
  //   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
  //   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
  //   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
  // ]

  useEffect(() => {
    const fetchForecastData = async () => {
      const inputData = {
        // xQuangNgai: xQuangNgai22to25.concat(xQuangNgai.map(Number)), // Convert strings to numbers
        // xDakTo: xDakTo22to25.concat(xDakTo.map(Number)) // Convert strings to numbers
        xQuangNgai: xQuangNgai, // Convert strings to numbers
        xDakTo: xDakTo // Convert strings to numbers
      }

      try {
        const response =
          inputData.xQuangNgai.length >= 24 ? await postData('forecast-dakdrinh/predict', inputData) : null

        inputData.xQuangNgai.splice(0, 24)
        inputData.xDakTo.splice(0, 24)
        dateTime.splice(0, 24)

        console.log(inputData.xQuangNgai.length, inputData.xDakTo.length, dateTime.length)

        // Transform data for Recharts
        const transformedData = inputData.xQuangNgai.map((value, index) => ({
          name: dateTime[index],
          XQuangNgai: value,
          XDakTo: inputData.xDakTo[index],
          Qden_DuBao: response[index]
        }))

        setForecastData(transformedData)
      } catch (error) {
        console.error('Error fetching forecast data:', error)
      }
    }

    fetchForecastData()
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [xDakTo, xQuangNgai]) // Add dependencies to useEffect if needed

  const [value, setValue] = React.useState(0)

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue)
  }

  const [page, setPage] = useState(0)
  const [rowsPerPage, setRowsPerPage] = useState(25)

  return (
    <div>
      <h1>Dự báo lưu lượng dòng chảy đến hồ Đăkđrinh</h1>
      <Tabs value={value} onChange={handleChange} aria-label='simple tabs example'>
        <Tab label='Biểu đồ' {...a11yProps(0)} />
        <Tab label='Bảng dữ liệu' {...a11yProps(1)} />
      </Tabs>
      <CustomTabPanel value={value} index={0}>
        {forecastData.length > 0 ? (
          <div style={{ width: '100%', height: 650 }}>
            <ResponsiveContainer>
              <ComposedChart
                data={forecastData}
                margin={{
                  top: 0,
                  right: 15,
                  left: 15,
                  bottom: 100
                }}>
                <CartesianGrid strokeDasharray='3 3' />
                <XAxis dataKey='name' angle={-45} textAnchor='end' />
                <YAxis
                  yAxisId='rainfall'
                  orientation='right'
                  domain={[0, (dataMax: number) => Math.ceil(dataMax * 5.5)]}
                  label={{
                    value: 'X(mm)',
                    angle: -90,
                    position: 'insideLeft',
                    style: { fontSize: '12px' }
                  }}
                  reversed={true}
                />
                <YAxis
                  yAxisId='flow'
                  orientation='left'
                  domain={[0, (dataMax: number) => Math.ceil(dataMax * 1.75)]}
                  label={{ value: 'Q(m3/s)', angle: -90, position: 'insideRight', style: { fontSize: '12px' } }}
                />
                <YAxis
                  yAxisId='waterLevel'
                  orientation='right'
                  domain={[365, 430]}
                  label={{ value: 'H(m)', angle: -90, position: 'insideLeft', style: { fontSize: '12px' } }}
                />
                <Tooltip />
                <Legend verticalAlign='top' height={36} />
                <Bar yAxisId='rainfall' dataKey='XQuangNgai' fill='blue' barSize={4} />
                <Bar yAxisId='rainfall' dataKey='XDakTo' fill='orange' barSize={4} />
                <Line
                  yAxisId='flow'
                  type='monotone'
                  dataKey='Qden_DuBao'
                  stroke='red'
                  strokeWidth={2}
                  dot={false}
                  strokeDasharray='3 3'
                />
                <ReferenceLine
                  yAxisId='waterLevel'
                  y={375}
                  stroke='#0073ff'
                  strokeWidth={1}
                  strokeDasharray='3 3'
                  label={{ value: 'Mực nước chết = 375(m)', position: 'insideBottomLeft', style: { fontSize: '12px' } }}
                />
                <ReferenceLine
                  yAxisId='waterLevel'
                  y={410}
                  stroke='#0073ff'
                  strokeWidth={1}
                  strokeDasharray='3 3'
                  label={{
                    value: 'Mực nước dâng bình thường = 410(m)',
                    position: 'insideBottomLeft',
                    style: { fontSize: '12px' }
                  }}
                />
                <ReferenceLine
                  yAxisId='waterLevel'
                  y={411.43}
                  stroke='#0073ff'
                  strokeWidth={1}
                  strokeDasharray='3 3'
                  label={{
                    value: 'Mực nước lũ thiết kế = 411.43(m)',
                    position: 'insideBottomLeft',
                    style: { fontSize: '12px' }
                  }}
                />
                <ReferenceLine
                  yAxisId='waterLevel'
                  y={414.88}
                  stroke='#0073ff'
                  strokeWidth={1}
                  strokeDasharray='3 3'
                  label={{
                    value: 'Mực nước lũ kiểm tra = 414.88(m)',
                    position: 'insideBottomLeft',
                    style: { fontSize: '12px' }
                  }}
                />
              </ComposedChart>
            </ResponsiveContainer>
          </div>
        ) : (
          <p>Loading forecast data...</p>
        )}
      </CustomTabPanel>
      <CustomTabPanel value={value} index={1}>
        <TableContainer component={Paper}>
          <Table size='small'>
            <TableHead>
              <TableRow>
                <TableCell rowSpan={2}>Thời gian</TableCell>
                <TableCell colSpan={2} align='center'>
                  Mưa (mm)
                </TableCell>
                <TableCell colSpan={2} align='center'>
                  Lưu lượng (m3/s)
                </TableCell>
                <TableCell rowSpan={2} align='center'>
                  Mực nước (m)
                </TableCell>
              </TableRow>
              <TableRow>
                <TableCell align='center'>Quảng Ngãi</TableCell>
                <TableCell align='center'>ĐăkTô</TableCell>
                <TableCell align='center'>Đến</TableCell>
                <TableCell align='center'>Dự báo</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {forecastData.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage).map((row: any) => (
                <TableRow key={row.name}>
                  <TableCell component='th' scope='row'>
                    {row.name}
                  </TableCell>
                  <TableCell align='right'>{row.XQuangNgai}</TableCell>
                  <TableCell align='right'>{row.XDakTo}</TableCell>
                  <TableCell align='right'>{row.Qden}</TableCell>
                  <TableCell align='right'>{row.Qden_DuBao.toFixed(2)}</TableCell>
                  <TableCell align='right'>{row.MucNuoc}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
          <TablePagination
            rowsPerPageOptions={[10, 25, 50, forecastData.length]}
            component='div'
            count={forecastData.length} // Ensure this is an integer
            rowsPerPage={rowsPerPage}
            page={page}
            onPageChange={(e, newPage) => setPage(newPage)}
            onRowsPerPageChange={e => setRowsPerPage(parseInt(e.target.value, 10))}
          />
        </TableContainer>
      </CustomTabPanel>
    </div>
  )
}

export default HoDakdrinhPage
