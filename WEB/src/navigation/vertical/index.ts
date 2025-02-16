// ** Icon imports
import HomeOutline from 'mdi-material-ui/HomeOutline'
import AccountCogOutline from 'mdi-material-ui/AccountCogOutline'

// ** Type import
import { VerticalNavItemsType } from 'src/@core/layouts/types'
import { ArrowBack, PeopleAltOutlined, Tv } from '@mui/icons-material'

const navigation = (router: any): VerticalNavItemsType => {
  const basePaths = {
    admin: '/quan-tri',
    cttuoi: '/cong-trinh-tuoi',
    datDai: '/dat-dai',
    dcks: '/dcks',
    moiTruong: '/moi-truong',
    kttv: '/kttv',
    bienDoiKh: '/bien-doi-khi-hau',
    doDacBanDo: '/do-dac-ban-do',
    moiTruongBien: '/moitruongbienvahaidao',
    duLieuVienTham: '/du-lieu-vien-tham'
  }

  const routes = {
    admin: [
      {
        title: 'Trang chủ',
        icon: HomeOutline,
        path: '/'
      },
      {
        title: 'Quản lý',
        children: [
          {
            title: 'Người dùng',
            icon: AccountCogOutline,
            path: `${basePaths.admin}/he-thong/nguoi-dung`
          },
          {
            title: 'Vai trò người dùng',
            icon: PeopleAltOutlined,
            path: `${basePaths.admin}/he-thong/nhom-nguoi-dung`
          },
          {
            title: 'Trang truy cập',
            icon: Tv,
            path: `${basePaths.admin}/he-thong/trang-truy-cap`
          }
        ]
      },
      {
        title: 'Phân quyền',
        children: [
          {
            title: 'Người dùng',
            icon: AccountCogOutline,
            path: `${basePaths.admin}/phan-quyen/nguoi-dung`
          },
          {
            title: 'Vai trò người dùng',
            icon: PeopleAltOutlined,
            path: `${basePaths.admin}/phan-quyen/nhom-nguoi-dung`
          }
        ]
      }
    ],
    cttuoi: [
      {
        title: 'QUẢN LÝ HỆ THỐNG TƯỚI',
        icon: ArrowBack,
        path: basePaths.cttuoi
      },

      {
        title: 'Công trình',
        children: [
          {
            title: 'Hồ chứa',
           path: `${basePaths.cttuoi}?page=cong-trinh-tuoi&type=ho-chua`
          },
          {
            title: 'Đập dâng',
           path: `${basePaths.cttuoi}?page=cong-trinh-tuoi&type=dap-dang`
          },
          {
            title: 'Cống  ',
              path: `${basePaths.cttuoi}?page=cong-trinh-tuoi&type=cong`
          },
          {
            title: 'Trạm bơm  ',
            path: `${basePaths.cttuoi}?page=ho-chua&type=1-den-3trieu-m3`
          },
          {
            title: 'Kênh ',
            path: `${basePaths.cttuoi}?page=ho-chua&type=02-den-1trieu-m3`
          },
          {
            title: 'Công trình khác ',
           path: `${basePaths.cttuoi}?page=ho-chua&type=005-den-02trieu-m3`
          },
    
        ]
      },

      

     
      {
        title: 'Dữ liệu vùng tưới',
        children: [
          {
            title: 'Lúa',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=thong-so`
          },
          {
            title: 'Cây công nghiệp ngắn ngày',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=quan-he-zvf`
          },
          {
            title: 'Cây công nghiệp dài ngày ',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=quy-dinh-MNVH`
          },
          {
            title: 'Nuôi trồng thủy sản ',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=quy-dinh-MNVH`
          },
          {
            title: 'Loại khác ',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=quy-dinh-MNVH`
          },
        ] 
      },

      {
        title: 'Quan trắc, vận hành',
        children: [
          {
            title: 'Hồ chứa',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=thong-so`
          },
          {
            title: 'Lượng mưa',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=quan-he-zvf`
          },
          {
            title: 'Mực nước ',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=quy-dinh-MNVH`
          },
        ] 
      },

      {
        title: 'Dữ liệu dự báo',
        children: [
          {
            title: 'Mưa',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=thong-so`
          },
          {
            title: 'Nguồn nước đến hồ',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=quan-he-zvf`
          },
          {
            title: 'Mực nước',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=quy-dinh-MNVH`
          },
        ] 
      },
      {
        title: 'Nhu cầu sử dụng nước',
        children: [
          {
            title: 'Quản lý mùa vụ',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=thong-so`
          },
          {
            title: 'Danh mục cây trồng',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=quan-he-zvf`
          },
          {
            title: 'Kế hoạch cấp nước',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=quy-dinh-MNVH`
          },
          {
            title: 'Nhu cầu sử dụng nước',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=quy-dinh-MNVH`
          },
        ] 
      },
      {
        title: 'Cân bằng nước',
        children: [
          {
            title: 'Hệ thống tưới thiếu nước',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=thong-so`
          },
          {
            title: 'Hệ thống tưới đủ nước',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=quan-he-zvf`
          },
        ] 
      },
      {
        title: 'Tổng hợp hệ thống tưới',
        children: [
          {
            title: 'Khả năng cấp nước HC',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=thong-so`
          },
          {
            title: 'Cơ cấu cây trồng theo mùa vụ',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=quan-he-zvf`
          },
          {
            title: 'Cân bằng nước theo hồ chứa',
            path: `${basePaths.cttuoi}?page=thong-so-ho-chua&type=quan-he-zvf`
          },
        ] 
      },

      {
        title: 'Thông báo - cảnh báo',
        children: [
          {
            title: 'Thông báo',
            path: `${basePaths.cttuoi}/thong-bao`
          },
          {
            title: 'Cảnh báo',
            path: `${basePaths.cttuoi}/canh-bao`
          }
        ]
      },

      {
        title: 'Hướng dẫn sử dụng',
        path: '/pdf/huongdansudung_TNN.pdf'
      }
    ],
       
  }

  //quan tri
  if (router.pathname.includes('quan-tri')) {
    return routes.admin
  }

 

  // Default return
  return []
}

export default navigation
