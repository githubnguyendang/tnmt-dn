import { Box, Tab, Typography } from '@mui/material'
import { useTheme } from '@mui/material/styles'
import TableComponent, { TableColumn } from 'src/@core/components/table'
import { TabContext, TabList, TabPanel } from '@mui/lab'
import { useEffect, useState } from 'react'
import ReactApexcharts from 'src/@core/components/react-apexcharts'
import { ApexOptions } from 'apexcharts'
import DialogsControlFullScreen from 'src/@core/components/dialog-control-full-screen'
import dayjs from 'dayjs'
import { VisibilityOutlined } from '@mui/icons-material'

const Detail = () => {
  const loading = false
  const [tab, setTab] = useState('1')

  const columnsTableDetail: TableColumn[] = [
    {
      id: 'date',
      label: 'Ngày'
    },
    {
      id: '#',
      label: 'Lượng mưa (mm)',
      align: 'left',
      children: [
        { id: '1h', label: '1h', align: 'center', elm: (row: any) => row.data[0] },
        { id: '4h', label: '4h', align: 'center', elm: (row: any) => row.data[1] },
        { id: '7h', label: '7h', align: 'center', elm: (row: any) => row.data[2] },
        { id: '10h', label: '10h', align: 'center', elm: (row: any) => row.data[3] },
        { id: '13h', label: '13h', align: 'center', elm: (row: any) => row.data[4] },
        { id: '16h', label: '16h', align: 'center', elm: (row: any) => row.data[5] },
        { id: '19h', label: '19h', align: 'center', elm: (row: any) => row.data[6] },
        { id: '22h', label: '22h', align: 'center', elm: (row: any) => row.data[7] },
        {
          id: 'total',
          label: 'Tổng',
          align: 'center',
          elm: (row: any) => {
            return (
              <Typography variant='overline' fontWeight={700} color={'blue'}>
                {row.data
                  .reduce((accumulator: number, currentValue: string | null) => {
                    // Convert current value to a number, treating null or undefined as 0
                    const value = currentValue == null ? 0 : parseFloat(currentValue)
                    // Add the value to the accumulator

                    return accumulator + value
                  }, 0)
                  .toFixed(2)}
              </Typography>
            )
          }
        }
      ]
    }
  ]

  const handleChange = (event: React.SyntheticEvent, newValue: string) => {
    setTab(newValue)
  }

  const [weatherData, setWeatherData] = useState<any>(null)

  const getWeather = async (lat: number, lon: number) => {
    console.log(lat, lon)

    // const response = await fetch('https://api.windy.com/api/point-forecast/v2', {
    //     method: 'POST',
    //     headers: {
    //         'Content-Type': 'application/json',
    //     },
    //     body: JSON.stringify({
    //         lat: lat,
    //         lon: lon,
    //         model: 'gfs',
    //         parameters: ['precip'],
    //         levels: ['surface'],
    //         key: 'ndpjIsjcOQtImOGy6QyjqMGbYVvLbKaw',
    //     }),
    // });

    // const data = await response.json();

    const data = {
      ts: [
        1722373200000, 1722384000000, 1722394800000, 1722405600000, 1722416400000, 1722427200000, 1722438000000,
        1722448800000, 1722459600000, 1722470400000, 1722481200000, 1722492000000, 1722502800000, 1722513600000,
        1722524400000, 1722535200000, 1722546000000, 1722556800000, 1722567600000, 1722578400000, 1722589200000,
        1722600000000, 1722610800000, 1722621600000, 1722632400000, 1722643200000, 1722654000000, 1722664800000,
        1722675600000, 1722686400000, 1722697200000, 1722708000000, 1722718800000, 1722729600000, 1722740400000,
        1722751200000, 1722762000000, 1722772800000, 1722783600000, 1722794400000, 1722805200000, 1722816000000,
        1722826800000, 1722837600000, 1722848400000, 1722859200000, 1722870000000, 1722880800000, 1722891600000,
        1722902400000, 1722913200000, 1722924000000, 1722934800000, 1722945600000, 1722956400000, 1722967200000,
        1722978000000, 1722988800000, 1722999600000, 1723010400000, 1723021200000, 1723032000000, 1723042800000,
        1723053600000, 1723064400000, 1723075200000, 1723086000000, 1723096800000, 1723107600000, 1723118400000,
        1723129200000, 1723140000000, 1723150800000, 1723161600000, 1723172400000, 1723183200000, 1723194000000,
        1723204800000, 1723215600000, 1723226400000
      ],
      units: {
        'past3hprecip-surface': 'm'
      },
      'past3hprecip-surface': [
        0, 0.0008468699850459207, 0, 0.0002700679555650445, 0, 0, 0, 0, 0.0000067385601367234335,
        0.00005287897885067243, 0, 0, 0, 0, 0.00021983832514420621, 0, 0, 0.000046140418713949, 0.00014694524674214792,
        0, 0, 0.0015401497543259394, 0.0014672062807092221, 0.00000786165349284343, 0, 0, 0.000032756889553513054, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.0006255270027772029, 0, 0, 0, 0, 0, 0, 0, 0, 0.000048012240974148574,
        0.000048012240974148574, 0, 0, 0, 0, 0, 0, 0, 0.003129334052552826, 0.0005216840632343533, 0,
        0.00045835167699209017, 0.001962468852809254, 0.000570545823541962, 0.00007290747703481821, 0, 0, 0, 0, 0, 0,
        0.001338662486648112, 0.0000802075838496014, 0, 0, 0.00007403776970732974, 0, 0.00021872243110445617,
        0.00020898895535141312, 0, 0.000050884768211924
      ],
      warning:
        'The trial API version is for development purposes only. This data is randomly shuffled and slightly modified.'
    }
    formatData(data)
  }

  function formatData(data: any) {
    const formattedData: any = []
    const precipitationData = data['past3hprecip-surface']

    // Multiply each value by 1000 and fix to 2 decimal places
    const adjustedPrecipitationData = precipitationData.map(
      (value: number) => (value == 0 ? null : (value * 1000).toFixed(2))

      // (value * 1000).toFixed(2)
    )

    // Lấy 7 index đầu tiên của precipitationData[0] và thêm 0 vào đầu
    formattedData.push([0, ...adjustedPrecipitationData.slice(0, 7)])

    for (let i = 7; i < adjustedPrecipitationData.length; i += 8) {
      const chunk = adjustedPrecipitationData.slice(i, i + 8)
      formattedData.push(chunk)
    }

    //cắt bỏ index cuối vì là 1h của ngày thứ 11
    formattedData.pop()

    const unixTimes = data['ts']
    const uniqueDates = convertAndUniqueDates(unixTimes)

    //cắt bỏ index cuối vì là 1h của ngày thứ 11
    uniqueDates.shift()

    const completeData = uniqueDates.map((date, index) => ({
      date,
      data: formattedData[index]
    }))

    setWeatherData(completeData)
  }

  function convertAndUniqueDates(unixTimes: any) {
    const uniqueDates = new Set()

    unixTimes.forEach((timestamp: any) => {
      const date = new Date(timestamp)
      const dateString = date.toISOString().split('T')[0]
      uniqueDates.add(dateString)
    })

    return Array.from(uniqueDates)
  }

  useEffect(() => {
    getWeather(15.119, 108.81)
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])

  // Define the labels corresponding to the indices
  const labels = ['1h', '4h', '7h', '10h', '13h', '16h', '19h', '22h']

  const colors = ['#4b0248', '#0091b0', '#abd83b', '#4f8a6b', '#341974', '#958aea', '#dc568b', '#e5eb92']

  // Extract the categories (dates)
  const categories: string[] = weatherData?.map((entry: any) => entry.date)

  // Extract the series data
  const series = labels.map((label, index) => ({
    name: label,
    data: weatherData?.map((entry: any) => parseFloat(entry.data[index] as string))
  }))

  const options: ApexOptions = {
    chart: {
      stacked: false,
      toolbar: {
        show: true
      },
      zoom: {
        enabled: false
      }
    },
    dataLabels: {
      enabled: true
    },
    colors: colors,
    responsive: [
      {
        breakpoint: 480,
        options: {
          legend: {
            position: 'bottom',
            offsetX: -10,
            offsetY: 0
          }
        }
      }
    ],
    plotOptions: {
      bar: {
        dataLabels: {
          total: {
            enabled: true,
            style: {
              fontSize: '13px',
              fontWeight: 900
            }
          }
        }
      }
    },
    stroke: {
      curve: 'smooth'
    },
    xaxis: {
      title: {
        text: 'Thời gian'
      },
      categories: categories
    },
    yaxis: {
      title: {
        text: 'Lượng mưa(mm)'
      }
    },
    legend: {
      position: 'top',
      offsetY: 0,
      horizontalAlign: 'left'
    },
    fill: {
      opacity: 1
    }
  }
  const currentMonth = dayjs(new Date()).month() + 1 // Months are zero-indexed in dayjs
  // Add 10 days to the current date
  const newDate = dayjs(new Date()).add(9, 'day')

  // Get the month of the new date
  const newMonth = newDate.month() + 1 // Months are zero-indexed in dayjs

  return (
    <Box sx={{}}>
      <TabContext value={tab}>
        <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
          <TabList onChange={handleChange} aria-label='lab API tabs example'>
            <Tab label='Số liệu' value='1' />
            <Tab label='Biểu đồ' value='2' />
          </TabList>
        </Box>
        <TabPanel value='1'>
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
          </Box>
        </TabPanel>
        <TabPanel value='2'>
          <Box>
            <ReactApexcharts options={options} series={series} type='line' height={450} />
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
