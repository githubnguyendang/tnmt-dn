import { useState, useEffect } from 'react';
import { Grid } from '@mui/material';
import RequestDetails from './request-fieldset';
import RequestTableDetails from './table-detail';
import SearchRequest from './search';
import dynamic from 'next/dynamic';
import { getData } from 'src/api/axios';

const Map = dynamic(() => import('src/@core/components/map'), { ssr: false });

const RequestCon = () => {
  const [mapCenter] = useState([15.012172, 108.676488]);
  const [mapZoom] = useState(9);
  const [constructionData, setConstructionData] = useState(null); // Dữ liệu từ API
  const [loading, setLoading] = useState(false);

  const fetchConstructionData = async () => {
    setLoading(true);
    try {
      const data = await getData('cong-trinh/danh-sach', {
        tenct: '',
        loai_ct: 0,
        huyen: 0,
        xa: 0,
        song: 0,
        luuvuc: 0,
        tieu_luuvuc: 0,
        tang_chuanuoc: 0,
        tochuc_canhan: 0,
        nguonnuoc_kt: ''
      });
      setConstructionData(data?.[0] || null); // Lấy công trình đầu tiên
    } catch (error) {
      console.error('Error fetching construction data:', error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchConstructionData();
  }, []);

  return (
    <Grid container spacing={2}>
      <Grid item xs={8}>
        <SearchRequest />
        <RequestDetails data={constructionData} loading={loading} /> {/* Truyền dữ liệu */}
        <RequestTableDetails />
      </Grid>
      <Grid item xs={4} sx={{ width: '100%', height: 'calc( 100vh - 120px )' }}>
        <Map center={mapCenter} zoom={mapZoom} mapData={null} loading={false} />
      </Grid>
    </Grid>
  );
};

export default RequestCon;
