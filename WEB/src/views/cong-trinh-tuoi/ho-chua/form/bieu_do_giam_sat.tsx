import React from 'react'
import { ResponsiveContainer, LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend } from 'recharts'
import { formatDateTime } from 'src/@core/components/formater'

interface HeThongGiamSatProps {
  dataStorage: any
  dataCons: { tenCT: string }
}

const BieuDoGiamSat: React.FC<HeThongGiamSatProps> = ({ dataStorage, dataCons }) => {
  // Chuyển đổi định dạng thời gian
  const formattedData = dataStorage.map((item: any) => ({
    ...item,
    time: formatDateTime(item.time) // Chuyển đổi định dạng thời gian
  }))

  return (
    <div>
      <h3 style={{ textAlign: 'center' }}>{dataCons?.tenCT}</h3>
      <ResponsiveContainer width='100%' height={400}>
        <LineChart data={formattedData} margin={{ top: 20, right: 30, left: 20, bottom: 5 }}>
          <CartesianGrid strokeDasharray='3 3' />
          {/* Trục X lấy từ dataStorage.time */}
          <XAxis dataKey='time' />
          {/* Trục Y bên trái cho các giá trị Thượng Lưu, Hạ Lưu */}
          <YAxis yAxisId='left' label={{ value: 'Mực Nước', angle: -90, position: 'insideLeft' }} />
          {/* Trục Y bên phải cho các giá trị lưu lượng */}
          <YAxis
            yAxisId='right'
            orientation='right'
            label={{ value: 'Lưu Lượng', angle: -90, position: 'insideRight' }}
          />
          <Tooltip />
          <Legend />

          {/* Đường biểu diễn cho Mực nước hồ */}
          <Line yAxisId='left' type='monotone' dataKey='data.THUONGLUU' stroke='#1f77b4' name='Mực nước hồ (m)' />

          {/* Đường biểu diễn cho Lưu lượng xả duy trì */}
          <Line
            yAxisId='right'
            type='monotone'
            dataKey='data.DCTT'
            stroke='#2ca02c'
            name='Lưu lượng xả duy trì DCTT (m³/s)'
          />

          {/* Đường biểu diễn cho Lưu lượng xả qua nhà máy */}
          <Line
            yAxisId='right'
            type='monotone'
            dataKey='data.NHAMAY'
            stroke='#ff7f0e'
            name='Lưu lượng xả qua nhà máy (m³/s)'
          />

          {/* Đường biểu diễn cho Lưu lượng xả qua tràn */}
          <Line
            yAxisId='right'
            type='monotone'
            dataKey='data.QUATRAN'
            stroke='#d62728'
            name='Lưu lượng xả qua tràn (m³/s)'
          />

          {/* Đường biểu diễn cho Lưu lượng về hạ du */}
          <Line
            yAxisId='right'
            type='monotone'
            dataKey='data.LUULUONGVEHALUU'
            stroke='#9467bd'
            name='Lưu lượng về hạ du (m³/s)'
          />
        </LineChart>
      </ResponsiveContainer>
    </div>
  )
}

export default BieuDoGiamSat
