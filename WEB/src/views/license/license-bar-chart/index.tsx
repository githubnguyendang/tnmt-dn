import { Paper } from '@mui/material'
import React, { useState } from 'react'
import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, Legend, LabelList, ResponsiveContainer } from 'recharts'

export interface RechartLicenseProps {
  series: any
  year: any
  color: any
}

// Custom label renderer to hide labels with value 0, null, undefined, or ''
const renderCustomLabel = (props: any) => {
  const { x, y, width, height, value } = props

  if (value === 0 || value === null || value === undefined || value === '') {
    return null
  }

  return (
    <text x={x + width / 2} y={y + height} fill='#fff' textAnchor='middle' dy={-6}>
      {value}
    </text>
  )
}

// Add this custom component for total labels
const CustomTotalLabel = (props: any) => {
  const { x, width, value } = props

  return (
    <text
      x={x + width / 20}
      y={20} // Fixed Y position at the top
      fill='#777'
      textAnchor='middle'
      fontSize='12px'
      style={{ pointerEvents: 'none' }}>
      {`Tổng: ${value}`}
    </text>
  )
}

const CustomTooltip = (props: any) => {
  const { active, payload, label } = props

  if (active && payload && payload.length) {
    return (
      <Paper
        component={'div'}
        sx={{
          padding: '10px',
          backgroundColor: 'rgba(255, 255, 255, 0.95)',
          border: '1px solid #ccc'
        }}>
        <p style={{ margin: '0 0 5px 0', fontWeight: 'bold' }}>Năm: {label}</p>
        {payload.map((item: any, index: number) => (
          <p key={index} style={{ margin: '3px 0', color: item.color }}>
            {item.name}: {item.value}
          </p>
        ))}
        {/* <p style={{ margin: '5px 0 0 0', borderTop: '1px solid #ccc', paddingTop: '5px' }}>
          Tổng: {payload.reduce((sum: number, item: any) => sum + (item.value || 0), 0)}
        </p> */}
      </Paper>
    )
  }

  return null
}

const RechartLicense: React.FC<RechartLicenseProps> = ({ series, year, color }) => {
  const [activeSeries, setActiveSeries] = useState<Array<string>>([])
  const handleLegendClick = (dataKey: string) => {
    if (activeSeries.includes(dataKey)) {
      setActiveSeries(activeSeries.filter(el => el !== dataKey))
    } else {
      setActiveSeries(prev => [...prev, dataKey])
    }
  }

  // Prepare data for Recharts
  const data = year.map((yearLabel: string, index: number) => {
    const dataEntry: any = { year: yearLabel }
    series.forEach((seriesItem: any) => {
      dataEntry[seriesItem.name] = seriesItem.data[index]
    })

    return dataEntry
  })

  return (
    <ResponsiveContainer width='100%' height={444}>
      <BarChart data={data} margin={{ top: 20, right: 30, left: 20, bottom: 5 }}>
        <CartesianGrid strokeDasharray='3 3' />
        <XAxis
          dataKey='year'
          interval={0} // Show all labels
          padding={{ left: 20, right: 20 }} // Add padding to x-axis
        />
        <YAxis />
        <Tooltip content={<CustomTooltip />} />
        <Legend
          height={36}
          iconType='circle'
          onClick={(props: any) => handleLegendClick(props.dataKey)}
          wrapperStyle={{ paddingTop: '10px' }}
        />
        {series.map((seriesItem: any, index: number) => (
          <Bar
            key={index}
            hide={activeSeries.includes(seriesItem.name)}
            dataKey={seriesItem.name}
            fill={color[index]}
            stackId='a'>
            <LabelList dataKey={seriesItem.name} position='center' content={renderCustomLabel} />
          </Bar>
        ))}
        <Bar
          dataKey={(entry: any) =>
            series.reduce((sum: number, seriesItem: any) => sum + (entry[seriesItem.name] || 0), 0)
          }
          fill='transparent'
          isAnimationActive={false}>
          <LabelList content={CustomTotalLabel} />
        </Bar>
      </BarChart>
    </ResponsiveContainer>
  )
}

export default RechartLicense
