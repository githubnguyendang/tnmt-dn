import { Box, Paper, Typography } from '@mui/material'
import { useTheme } from '@mui/material/styles'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import { PureComponent, useEffect, useState } from 'react'
import DialogsControlFullScreen from 'src/@core/components/dialog-control-full-screen'
import dayjs from 'dayjs'
import { VisibilityOutlined } from '@mui/icons-material'
import { CartesianGrid, Legend, Line, LineChart, Tooltip, XAxis, YAxis } from 'recharts'

class CustomizedLabel extends PureComponent {
  render() {
    const { x, y, stroke, value }: any = this.props

    return (
      <text x={x} y={y} dy={-4} fill={stroke} fontSize={12} fontWeight={500} textAnchor='middle'>
        {value}
      </text>
    )
  }
}

const chartLineProps: any = {
  label: <CustomizedLabel />,
  strokeWidth: 1.5,
  connectNulls: false,
  dot: { strokeWidth: 1 }
}

const Detail = () => {
  const loading = false
  const timeSlots = ['00h', '03h', '06h', '09h', '12h', '15h', '18h', '21h']

  // Define colors for each line (you can define more colors if needed)
  const lineColors = ['#4b0248', '#0091b0', '#abd83b', '#4f8a6b', '#341974', '#958aea', '#dc568b', '#e53b12']

  const columnsTableDetail: TableColumn[] = [
    {
      id: 'date',
      label: 'Ngày'
    },
    {
      id: '#',
      label: 'Lượng mưa(mm) / giờ',
      align: 'left',
      children: [
        { id: '00h', label: '00h', align: 'center' },
        { id: '03h', label: '03h', align: 'center' },
        { id: '06h', label: '06h', align: 'center' },
        { id: '09h', label: '09h', align: 'center' },
        { id: '12h', label: '12h', align: 'center' },
        { id: '15h', label: '15h', align: 'center' },
        { id: '18h', label: '18h', align: 'center' },
        { id: '21h', label: '21h', align: 'center' },
        {
          id: 'total',
          label: 'Tổng',
          align: 'center',
          elm: (row: any) => {
            // Calculate the total precipitation for the row
            const total = timeSlots.reduce((sum, timeSlot) => {
              // Convert each value to a number and add to the sum
              return sum + (parseFloat(row[timeSlot]) || 0)
            }, 0)

            return (
              <Typography variant='inherit' fontWeight={700} color={'blue'}>
                {total.toFixed(2)} {/* Format the total to 2 decimal places */}
              </Typography>
            )
          }
        }
      ]
    }
  ]

  const [weatherData, setWeatherData] = useState<any>(null)

  const getWeather = async (lat: number, lon: number) => {
    console.log(lat, lon)

    // const response = await fetch('https://api.windy.com/api/point-forecast/v2', {
    //   method: 'POST',
    //   headers: {
    //     'Content-Type': 'application/json'
    //   },
    //   body: JSON.stringify({
    //     lat: lat,
    //     lon: lon,
    //     model: 'gfs',
    //     parameters: ['precip'],
    //     levels: ['surface'],
    //     key: 'ndpjIsjcOQtImOGy6QyjqMGbYVvLbKaw'
    //   })
    // })

    // const data = await response.json()

    const data = {
      ts: [
        1722826800000, 1722837600000, 1722848400000, 1722859200000, 1722870000000, 1722880800000, 1722891600000,
        1722902400000, 1722913200000, 1722924000000, 1722934800000, 1722945600000, 1722956400000, 1722967200000,
        1722978000000, 1722988800000, 1722999600000, 1723010400000, 1723021200000, 1723032000000, 1723042800000,
        1723053600000, 1723064400000, 1723075200000, 1723086000000, 1723096800000, 1723107600000, 1723118400000,
        1723129200000, 1723140000000, 1723150800000, 1723161600000, 1723172400000, 1723183200000, 1723194000000,
        1723204800000, 1723215600000, 1723226400000, 1723237200000, 1723248000000, 1723258800000, 1723269600000,
        1723280400000, 1723291200000, 1723302000000, 1723312800000, 1723323600000, 1723334400000, 1723345200000,
        1723356000000, 1723366800000, 1723377600000, 1723388400000, 1723399200000, 1723410000000, 1723420800000,
        1723431600000, 1723442400000, 1723453200000, 1723464000000, 1723474800000, 1723485600000, 1723496400000,
        1723507200000, 1723518000000, 1723528800000, 1723539600000, 1723550400000, 1723561200000, 1723572000000,
        1723582800000, 1723593600000, 1723604400000, 1723615200000, 1723626000000, 1723636800000, 1723647600000,
        1723658400000, 1723669200000, 1723680000000
      ],
      units: {
        'past3hprecip-surface': 'm'
      },
      'past3hprecip-surface': [
        0.00013683960997344443, 0.0002616542863246567, 0.00008599205755790718, 0, 0.00019556022064882867, 0, 0,
        0.0032037059007538203, 0.00025711478774376786, 0.0008199350871303309, 0.011156338900418342,
        0.0000073906826990570005, 0.000933405323953951, 0.00015043226416821463, 0.0013535027542954424, 0,
        0.007533707052827545, 0.00025967310098573814, 0, 0.000150389194921724, 0, 0.00041044130527665036,
        0.00009023007141331335, 0, 0.0005479441816461589, 0.00005239804528946755, 0, 0.0009942880108035484,
        0.0004643123187963315, 0.000023403828547012665, 0, 0, 0, 0, 0, 0.0007842909787285653, 0.00015840007477035167,
        0.0013986910077211606, 0.00015163820307016564, 0, 0, 0.0005365825144199831, 0.000022843928342539815, 0,
        0.0010967842036194778, 0, 0, 0, 0.00008103909421064156, 0, 0.0004482991729483759, 0, 0, 0, 0,
        0.0004179956511124075, 0.00038878608813745075, 0, 0.0002566927091280817, 0.00015921839045380555, 0, 0,
        0.000006822168645283882, 0.00007736098055970825, 0.00002160353404339788, 0, 0, 0, 0.0003374820017090406,
        0.008746037430951576, 0.000007442365794855022, 0.000388010841700488, 0, 0.00033518210394603586,
        0.0019752848521377643, 0.0000971642200994932, 0, 0, 0, 0
      ],
      warning:
        'The trial API version is for development purposes only. This data is randomly shuffled and slightly modified.'
    }
    processData(data.ts, data['past3hprecip-surface'])
  }

  function processData(ts: any[], rainForecastValue: number[]) {
    // Define a function to format the timestamp into a readable date
    function formatDate(timestamp: string | number | Date) {
      const date = new Date(timestamp)

      return date.toISOString().split('T')[0] // Get the date part in YYYY-MM-DD format
    }

    // Initialize the result array
    const result: any[] = []

    // Initialize a map to keep track of entries by date
    const dateMap: any = {}

    // Process each timestamp and value
    ts.forEach((timestamp, index) => {
      // Get the date for this entry
      const date = formatDate(timestamp)

      // Extract the time slot (hour) from the ISO string
      const isoString = new Date(timestamp).toISOString()
      const timeSlot = isoString.split('T')[1].split(':')[0] + 'h' // Extract hour and append 'h'

      // Initialize the entry for this date if not already present
      if (!dateMap[date]) {
        dateMap[date] = { date }
        result.push(dateMap[date])
      }

      const value = rainForecastValue?.[index]
      dateMap[date][timeSlot] = value !== null && value !== 0 ? (value * 1000).toFixed(2) : null
    })

    // Crop last day have only 1 data forcast
    result.pop()
    setWeatherData(
      // Ensure each object has all time keys including "00h"
      result?.map((entry: any) => {
        timeSlots.forEach(slot => {
          if (!entry.hasOwnProperty(slot)) {
            entry[slot] = null // Or use a default value like 0
          }
        })

        return entry
      })
    )
  }

  useEffect(() => {
    getWeather(15.119, 108.81)
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])

  const currentMonth = dayjs(new Date()).month() + 1 // Months are zero-indexed in dayjs
  // Add 10 days to the current date
  const newDate = dayjs(new Date()).add(9, 'day')

  // Get the month of the new date
  const newMonth = newDate.month() + 1 // Months are zero-indexed in dayjs

  return (
    <Box component={'div'}>
      <Typography variant='inherit' fontSize={16} p={2}>
        Lượng mưa dự báo từ ngày {dayjs(new Date()).date()}/{currentMonth}
        đến ngày {newDate.date()}/{newMonth} theo <a href='https://www.windy.com'>windy.com </a>
      </Typography>
      <TableComponent
        id='luongmuahientai'
        columns={columnsTableDetail}
        rows={weatherData}
        loading={loading}
        actions={() => <Box></Box>}
      />
      <Paper>
        <LineChart width={1440} height={400} data={weatherData} style={{ padding: 10, margin: '15px 0 0 0' }}>
          <CartesianGrid strokeDasharray='3 3' />
          <XAxis dataKey='date' />
          <YAxis
            label={{
              value: 'Lượng mưa (mm)',
              angle: -90,
              style: { textAnchor: 'middle', fontSize: 13 }
            }}
          />
          <Tooltip />
          <Legend />
          {timeSlots.map((key, index) => (
            <Line key={key} dataKey={key} stroke={lineColors[index % lineColors.length]} {...chartLineProps} />
          ))}
        </LineChart>
      </Paper>
    </Box>
  )
}

const ViewDetail = (station: string) => {
  const theme = useTheme()

  return (
    <DialogsControlFullScreen>
      {(openDialogs: (content: React.ReactNode, title: React.ReactNode) => void) => (
        <Box
          width={'100%'}
          display={'flex'}
          justifyContent={'space-between'}
          sx={{ cursor: 'pointer' }}
          alignItems={'center'}
          onClick={() => openDialogs(<Detail />, station)}>
          <Typography variant='caption' color={theme.palette.primary.dark}>
            {station}
          </Typography>
          <Typography variant='caption' sx={{ cursor: 'pointer' }} color={theme.palette.primary.dark}>
            <VisibilityOutlined />
          </Typography>
        </Box>
      )}
    </DialogsControlFullScreen>
  )
}
export default ViewDetail
