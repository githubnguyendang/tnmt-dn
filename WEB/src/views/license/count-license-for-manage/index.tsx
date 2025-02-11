import { Box, Typography, CircularProgress, Grid } from '@mui/material'
import { Recycling } from '@mui/icons-material'
import { useRouter } from 'next/router'

const COLORS = ['rgb(106, 179, 230)', 'rgb(0, 61, 126)', 'rgb(125, 95, 58)', 'rgb(0, 178, 151)', 'rgb(244, 153, 23)']
const CHARTS_LEGEND = [
  'KTSD nước mặt',
  'KTSD nước dưới đất',
  'Thăm dò nước dưới đất',
  'Hành nghề khoan',
  'Xả thải vào nguồn nước'
]

interface CountLicenseForManageProps {
  data?: any
  loading?: boolean
}

const CountLicenseForManage = (props: CountLicenseForManageProps) => {
  const { data, loading } = props
  const router = useRouter()

  const handleRedZoneClick = (loai_ct: string, hieu_luc?: string, coquan_cp?: string) => {
    router.push({
      pathname: `/tai-nguyen-nuoc/cap-phep/giay-phep/${
        loai_ct === 'ktsd_nm'
          ? 'nuoc-mat'
          : loai_ct === 'ktsd_ndd'
          ? 'nuoc-duoi-dat/khai-thac-su-dung'
          : loai_ct === 'thamdo_ndd'
          ? 'nuoc-duoi-dat/tham-do'
          : loai_ct === 'hnk_ndd'
          ? 'nuoc-duoi-dat/hanh-nghe-khoan'
          : loai_ct === 'xathai'
          ? 'xa-thai'
          : ''
      }`,
      query: {
        hieuluc_gp: hieu_luc == '' ? null : hieu_luc,
        coquan_cp: coquan_cp,
        loai_ct:
          loai_ct === 'ktsd_nm'
            ? 1
            : loai_ct === 'ktsd_ndd'
            ? 7
            : loai_ct === 'thamdo_ndd'
            ? 8
            : loai_ct === 'hnk_ndd'
            ? 9
            : loai_ct === 'xathai'
            ? 3
            : 0
      }
    })
  }

  console.log(data)

  return (
    <Grid container>
      {/* KTSD nước mặt */}
      <Grid item xs={12} md={4} sx={{ p: 2 }}>
        <Box
          sx={{
            backgroundColor: COLORS[0],
            borderRadius: 1,
            p: 2
          }}>
          <Typography
            p={2}
            fontWeight={'bold'}
            color={'#fff'}
            sx={{
              cursor: 'pointer'
            }}
            onClick={() => handleRedZoneClick('ktsd_nm')}>
            {CHARTS_LEGEND[0]} : {loading ? <CircularProgress size={20} color='inherit' /> : data.ktsd_nm?.total}
          </Typography>
          <Grid container sx={{ display: 'flex', flexWrap: 'wrap', justifyContent: 'center' }}>
            <Grid item xs={4} sx={{ p: 2 }}>
              <img src='/images/constructionTypes/surfaceWater.png' alt='license_img' width={65} height={65}></img>
            </Grid>
            <Grid item xs={8} sx={{ p: 2 }}>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('ktsd_nm', 'con-hieu-luc')}>
                Còn hiệu lực: {loading ? <CircularProgress size={20} color='inherit' /> : data.ktsd_nm?.con_hieuluc}
              </Typography>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('ktsd_nm', 'het-hieu-luc')}>
                Hết hiệu lực:{' '}
                {loading ? (
                  <CircularProgress size={20} color='inherit' />
                ) : (
                  data.ktsd_nm?.total - data.ktsd_nm?.con_hieuluc
                )}
              </Typography>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('ktsd_nm', '', 'BTNMT')}>
                BTNMT cấp: {loading ? <CircularProgress size={20} color='inherit' /> : data.ktsd_nm?.bo_cap}
              </Typography>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('ktsd_nm', '', 'UBNDT')}>
                UBND Tỉnh cấp: {loading ? <CircularProgress size={20} color='inherit' /> : data.ktsd_nm?.tinh_cap}
              </Typography>
            </Grid>
          </Grid>
        </Box>
      </Grid>

      {/* KTSD nước dưới đất */}
      <Grid item xs={12} md={4} sx={{ p: 2 }}>
        <Box
          sx={{
            backgroundColor: COLORS[1],
            borderRadius: 1,
            p: 2
          }}>
          <Typography
            p={2}
            fontWeight={'bold'}
            color={'#fff'}
            sx={{
              cursor: 'pointer'
            }}
            onClick={() => handleRedZoneClick('ktsd_ndd')}>
            {CHARTS_LEGEND[1]} : {loading ? <CircularProgress size={20} color='inherit' /> : data.ktsd_ndd?.total}
          </Typography>
          <Grid container sx={{ display: 'flex', flexWrap: 'wrap', justifyContent: 'center' }}>
            <Grid item xs={4} sx={{ p: 2 }}>
              <img src='/images/constructionTypes/probed.png' alt='license_img' width={65} height={65}></img>
            </Grid>
            <Grid item xs={8} sx={{ p: 2 }}>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('ktsd_ndd', 'con-hieu-luc')}>
                Còn hiệu lực: {loading ? <CircularProgress size={20} color='inherit' /> : data.ktsd_ndd?.con_hieuluc}
              </Typography>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('ktsd_ndd', 'het-hieu-luc')}>
                Hết hiệu lực:{' '}
                {loading ? (
                  <CircularProgress size={20} color='inherit' />
                ) : (
                  data.ktsd_ndd?.total - data.ktsd_ndd?.con_hieuluc
                )}
              </Typography>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('ktsd_ndd', '', 'BTNMT')}>
                BTNMT cấp: {loading ? <CircularProgress size={20} color='inherit' /> : data.ktsd_ndd?.bo_cap}
              </Typography>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('ktsd_ndd', '', 'UBNDT')}>
                UBND Tỉnh cấp: {loading ? <CircularProgress size={20} color='inherit' /> : data.ktsd_ndd?.tinh_cap}
              </Typography>
            </Grid>
          </Grid>
        </Box>
      </Grid>

      {/* Thăm dò nước dưới đất */}
      <Grid item xs={12} md={4} sx={{ p: 2 }}>
        <Box
          sx={{
            backgroundColor: COLORS[2],
            borderRadius: 1,
            p: 2
          }}>
          <Typography
            p={2}
            fontWeight={'bold'}
            color={'#fff'}
            sx={{
              cursor: 'pointer'
            }}
            onClick={() => handleRedZoneClick('thamdo_ndd')}>
            {CHARTS_LEGEND[2]} : {loading ? <CircularProgress size={20} color='inherit' /> : data.thamdo_ndd?.total}
          </Typography>
          <Grid container sx={{ display: 'flex', flexWrap: 'wrap', justifyContent: 'center' }}>
            <Grid item xs={4} sx={{ p: 2 }}>
              <img src='/images/constructionTypes/probed.png' alt='license_img' width={65} height={65}></img>
            </Grid>
            <Grid item xs={8} sx={{ p: 2 }}>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('thamdo_ndd', 'con-hieu-luc')}>
                Còn hiệu lực: {loading ? <CircularProgress size={20} color='inherit' /> : data.thamdo_ndd?.con_hieuluc}
              </Typography>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('thamdo_ndd', 'het-hieu-luc')}>
                Hết hiệu lực:{' '}
                {loading ? (
                  <CircularProgress size={20} color='inherit' />
                ) : (
                  data.thamdo_ndd?.total - data.thamdo_ndd?.con_hieuluc
                )}
              </Typography>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('thamdo_ndd', '', 'BTNMT')}>
                BTNMT cấp: {loading ? <CircularProgress size={20} color='inherit' /> : data.thamdo_ndd?.bo_cap}
              </Typography>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('thamdo_ndd', '', 'UBNDT')}>
                UBND Tỉnh cấp: {loading ? <CircularProgress size={20} color='inherit' /> : data.thamdo_ndd?.tinh_cap}
              </Typography>
            </Grid>
          </Grid>
        </Box>
      </Grid>

      {/* Hành nghề khoan */}
      <Grid item xs={12} md={4} sx={{ p: 2 }}>
        <Box
          sx={{
            backgroundColor: COLORS[3],
            borderRadius: 1,
            p: 2
          }}>
          <Typography
            p={2}
            fontWeight={'bold'}
            color={'#fff'}
            sx={{
              cursor: 'pointer'
            }}
            onClick={() => handleRedZoneClick('hnk_ndd')}>
            {CHARTS_LEGEND[3]} : {loading ? <CircularProgress size={20} color='inherit' /> : data.hnk_ndd?.total}
          </Typography>
          <Grid container sx={{ display: 'flex', flexWrap: 'wrap', justifyContent: 'center' }}>
            <Grid item xs={4} sx={{ p: 2 }}>
              <img src='/images/constructionTypes/drilling-practice.png' alt='license_img' width={65} height={65}></img>
            </Grid>
            <Grid item xs={8} sx={{ p: 2 }}>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('hnk_ndd', 'con-hieu-luc')}>
                Còn hiệu lực: {loading ? <CircularProgress size={20} color='inherit' /> : data.hnk_ndd?.con_hieuluc}
              </Typography>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('hnk_ndd', 'het-hieu-luc')}>
                Hết hiệu lực:{' '}
                {loading ? (
                  <CircularProgress size={20} color='inherit' />
                ) : (
                  data.hnk_ndd?.total - data.hnk_ndd?.con_hieuluc
                )}
              </Typography>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('hnk_ndd', '', 'BTNMT')}>
                BTNMT cấp: {loading ? <CircularProgress size={20} color='inherit' /> : data.hnk_ndd?.bo_cap}
              </Typography>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('hnk_ndd', '', 'UBNDT')}>
                UBND Tỉnh cấp: {loading ? <CircularProgress size={20} color='inherit' /> : data.hnk_ndd?.tinh_cap}
              </Typography>
            </Grid>
          </Grid>
        </Box>
      </Grid>

      {/* Xả thải */}
      <Grid item xs={12} md={4} sx={{ p: 2 }}>
        <Box
          sx={{
            backgroundColor: COLORS[4],
            borderRadius: 1,
            p: 2
          }}>
          <Typography
            p={2}
            fontWeight={'bold'}
            color={'#fff'}
            sx={{
              cursor: 'pointer'
            }}
            onClick={() => handleRedZoneClick('xathai')}>
            {CHARTS_LEGEND[4]} : {loading ? <CircularProgress size={20} color='inherit' /> : data.xathai?.total}
          </Typography>
          <Grid container sx={{ display: 'flex', flexWrap: 'wrap', justifyContent: 'center' }}>
            <Grid item xs={4} sx={{ p: 2 }}>
              <Recycling sx={{ width: 65, height: 65, color: '#fff' }} />
            </Grid>
            <Grid item xs={8} sx={{ p: 2 }}>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('xathai', 'con-hieu-luc')}>
                Còn hiệu lực: {loading ? <CircularProgress size={20} color='inherit' /> : data.xathai?.con_hieuluc}
              </Typography>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('xathai', 'het-hieu-luc')}>
                Hết hiệu lực:{' '}
                {loading ? (
                  <CircularProgress size={20} color='inherit' />
                ) : (
                  data.xathai?.total - data.xathai?.con_hieuluc
                )}
              </Typography>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('xathai', '', 'BTNMT')}>
                BTNMT cấp: {loading ? <CircularProgress size={20} color='inherit' /> : data.xathai?.bo_cap}
              </Typography>
              <Typography
                variant='body2'
                py={1}
                fontWeight={'bold'}
                color={'#fff'}
                sx={{
                  cursor: 'pointer'
                }}
                onClick={() => handleRedZoneClick('xathai', '', 'UBNDT')}>
                UBND Tỉnh cấp: {loading ? <CircularProgress size={20} color='inherit' /> : data.xathai?.tinh_cap}
              </Typography>
            </Grid>
          </Grid>
        </Box>
      </Grid>
    </Grid>
  )
}

export default CountLicenseForManage
