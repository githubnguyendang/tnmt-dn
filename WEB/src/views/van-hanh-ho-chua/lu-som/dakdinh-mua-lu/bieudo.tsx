import { Paper, Typography } from '@mui/material'
import { ApexOptions } from 'apexcharts'
import { useEffect, useState } from 'react'
import ReactApexcharts from 'src/@core/components/react-apexcharts'

export interface BieuDoMucNuocProps {
  series: any
  year: any
  color: any
}

interface Annotation {
  x: any
  y: number
}

// Define the addStackedTotalsAnnotations function outside the component
const addStackedTotalsAnnotations = (series: any, year: any, setAnnotations: (annotations: Annotation[]) => void) => {
  const seriesData = series?.map((seriesItem: any) => seriesItem.data)
  const stackedTotals = Array.from({ length: seriesData?.[0]?.length }, () => 0)

  for (let i = 0; i < seriesData?.length; i++) {
    for (let j = 0; j < seriesData[i]?.length; j++) {
      stackedTotals[j] += seriesData[i][j]
    }
  }

  const newAnnotations: Annotation[] = stackedTotals.map((total, index) => ({
    x: year[index],
    y: total
  }))

  setAnnotations(newAnnotations)
}

const BieuDoMucNuoc: React.FC<BieuDoMucNuocProps> = ({ series, year, color }) => {
  const [annotations, setAnnotations] = useState<Annotation[]>([])

  useEffect(() => {
    // Call the annotation function here after the series data is fetched and set
    addStackedTotalsAnnotations(series, year, setAnnotations)
  }, [series, year, setAnnotations])

  const options: ApexOptions = {
    annotations: {
      points: annotations
    },
    legend: {
      show: true,
      position: 'bottom'
    },
    colors: color,
    dataLabels: {
      enabled: true
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: '30%'
      }
    },
    chart: {
      type: 'line', // Đổi loại biểu đồ thành 'line'
      height: 300,
      width: '100%',
      stacked: true,
      events: {
        mounted: function () {
          addStackedTotalsAnnotations(series, year, setAnnotations)
        }
      }
    },
    xaxis: {
      categories: year
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
    <Paper>
      <Typography sx={{ py: 4 }} className='title_header'>
        BIỂU ĐỒ QUÁ TRÌNH MỰC NƯỚC VÀ LƯU LƯỢNG{' '}
      </Typography>
      <ReactApexcharts
        options={options}
        series={series}
        type='line' // Đổi loại biểu đồ thành 'line'
        width={options.chart?.width}
        height={options.chart?.height}
      />
    </Paper>
  )
}

export default BieuDoMucNuoc
