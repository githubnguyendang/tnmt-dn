// ** MUI Imports
import { Typography, Grid, Paper } from '@mui/material'
import BoxLoading from 'src/@core/components/box-loading'

// ** Recharts
import { PieChart, Pie, Cell, Tooltip, Legend } from 'recharts'

const CountLicense = ({ data, loading }: any) => {
  const TotalLicense = data.total
  const BTNMT = data.btnmt
  const UBND = data.ubnd

  // Chart
  const COLORS = ['#0088FE', '#FFBB28']
  const CHARTS_SIZE = 200
  const chartData = [
    { name: 'BTNMT', value: BTNMT },
    { name: 'UBND', value: UBND }
  ]

  return (
    <Paper>
      <Paper elevation={3} sx={{ py: 0.5, mb: 2, BorderRadius: 0, textAlign: 'center' }}>
        <Typography variant='overline' sx={{ fontWeight: 'bold' }}>
          giấy phép đã cấp
        </Typography>
      </Paper>
      {loading ? (
        <BoxLoading />
      ) : (
        <Grid container>
          <Grid
            item
            xs={5}
            md={5}
            sx={{ display: 'flex', justifyContent: 'space-between', flexWrap: 'wrap', alignItems: 'center' }}>
            <Grid item xs={12} sx={{ textAlign: 'center' }}>
              <Typography sx={{ fontWeight: 'bold' }} variant='h6'>
                TỔNG SỐ
              </Typography>
              <Typography sx={{ fontWeight: 'bold' }} variant='h6'>
                {TotalLicense}
              </Typography>
            </Grid>
            <Grid item xs={12} px={4}>
              <Typography variant='subtitle1'>
                <Typography sx={{ fontWeight: 'bold' }} variant='caption'>
                  BTNMT: {BTNMT}
                </Typography>
              </Typography>
              <Typography variant='subtitle1'>
                <Typography sx={{ fontWeight: 'bold' }} variant='caption'>
                  UBND: {UBND}
                </Typography>
              </Typography>
            </Grid>
          </Grid>
          <Grid item xs={7} md={7}>
            {/* Chart */}
            <PieChart width={CHARTS_SIZE} height={CHARTS_SIZE}>
              <Pie
                data={chartData}
                cx='50%'
                cy='50%'
                labelLine={false}
                label={({ name, value }) => `${name}: ${value}`}
                outerRadius={80}
                fill='#8884d8'
                dataKey='value'>
                {chartData.map((entry, index) => (
                  <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
                ))}
              </Pie>
              <Tooltip />
              <Legend />
            </PieChart>
          </Grid>
        </Grid>
      )}
    </Paper>
  )
}

export default CountLicense
