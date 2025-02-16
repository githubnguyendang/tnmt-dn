// ** Icon imports
import HomeOutline from 'mdi-material-ui/HomeOutline'
import AccountCogOutline from 'mdi-material-ui/AccountCogOutline'

// ** Type import
import { VerticalNavItemsType } from 'src/@core/layouts/types'
import { ArrowBack, PeopleAltOutlined, Tv } from '@mui/icons-material'

const navigation = (router: any): VerticalNavItemsType => {
  const basePaths = {
    admin: '/quan-tri',
    tnn: '/tai-nguyen-nuoc',
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
    tnn: [
      {
        title: 'QUẢN LÝ HỆ THỐNG TƯỚI',
        icon: ArrowBack,
        path: basePaths.tnn
      },

      {
        title: 'Công trình',
        children: [
          {
            title: 'Hồ chứa',
           path: `${basePaths.tnn}?page=cong-trinh-tuoi&type=ho-chua`
          },
          {
            title: 'Đập dâng',
           path: `${basePaths.tnn}?page=cong-trinh-tuoi&type=dap-dang`
          },
          {
            title: 'Cống  ',
              path: `${basePaths.tnn}?page=cong-trinh-tuoi&type=cong`
          },
          {
            title: 'Trạm bơm  ',
            path: `${basePaths.tnn}?page=ho-chua&type=1-den-3trieu-m3`
          },
          {
            title: 'Kênh ',
            path: `${basePaths.tnn}?page=ho-chua&type=02-den-1trieu-m3`
          },
          {
            title: 'Công trình khác ',
           path: `${basePaths.tnn}?page=ho-chua&type=005-den-02trieu-m3`
          },
    
        ]
      },

      

     
      {
        title: 'Dữ liệu vùng tưới',
        children: [
          {
            title: 'Lúa',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=thong-so`
          },
          {
            title: 'Cây công nghiệp ngắn ngày',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=quan-he-zvf`
          },
          {
            title: 'Cây công nghiệp dài ngày ',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=quy-dinh-MNVH`
          },
          {
            title: 'Nuôi trồng thủy sản ',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=quy-dinh-MNVH`
          },
          {
            title: 'Loại khác ',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=quy-dinh-MNVH`
          },
        ] 
      },

      {
        title: 'Quan trắc, vận hành',
        children: [
          {
            title: 'Hồ chứa',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=thong-so`
          },
          {
            title: 'Lượng mưa',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=quan-he-zvf`
          },
          {
            title: 'Mực nước ',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=quy-dinh-MNVH`
          },
        ] 
      },

      {
        title: 'Dữ liệu dự báo',
        children: [
          {
            title: 'Mưa',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=thong-so`
          },
          {
            title: 'Nguồn nước đến hồ',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=quan-he-zvf`
          },
          {
            title: 'Mực nước',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=quy-dinh-MNVH`
          },
        ] 
      },
      {
        title: 'Nhu cầu sử dụng nước',
        children: [
          {
            title: 'Quản lý mùa vụ',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=thong-so`
          },
          {
            title: 'Danh mục cây trồng',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=quan-he-zvf`
          },
          {
            title: 'Kế hoạch cấp nước',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=quy-dinh-MNVH`
          },
          {
            title: 'Nhu cầu sử dụng nước',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=quy-dinh-MNVH`
          },
        ] 
      },
      {
        title: 'Cân bằng nước',
        children: [
          {
            title: 'Hệ thống tưới thiếu nước',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=thong-so`
          },
          {
            title: 'Hệ thống tưới đủ nước',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=quan-he-zvf`
          },
        ] 
      },
      {
        title: 'Tổng hợp hệ thống tưới',
        children: [
          {
            title: 'Khả năng cấp nước HC',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=thong-so`
          },
          {
            title: 'Cơ cấu cây trồng theo mùa vụ',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=quan-he-zvf`
          },
          {
            title: 'Cân bằng nước theo hồ chứa',
            path: `${basePaths.tnn}?page=thong-so-ho-chua&type=quan-he-zvf`
          },
        ] 
      },

      {
        title: 'Thông báo - cảnh báo',
        children: [
          {
            title: 'Thông báo',
            path: `${basePaths.tnn}/thong-bao`
          },
          {
            title: 'Cảnh báo',
            path: `${basePaths.tnn}/canh-bao`
          }
        ]
      },

      {
        title: 'Hướng dẫn sử dụng',
        path: '/pdf/huongdansudung_TNN.pdf'
      }
    ],
    tnnVHLHC: [
      {
        title: 'VẬN HÀNH LIÊN HỒ CHỨA',
        icon: ArrowBack,
        path: basePaths.tnn
      },
      {
        title: 'Thông tin lưu vực',
        children: [
          {
            title: 'Dữ liệu lưu vực',
            path: `${basePaths.tnn}/van-hanh/du-lieu-luu-vuc`
          },
          {
            title: 'Dữ liệu hồ chứa',
            path: `${basePaths.tnn}/van-hanh/du-lieu-ho-chua`
          }
        ]
      },
      {
        title: 'Quy định vận hành -QĐ911',
        children: [
          {
            title: 'Đầy đủ ',
            path: `${basePaths.tnn}/van-hanh/quy-dinh-van-hanh/day-du`
          },
          {
            title: 'Rút gọn ',
            path: `${basePaths.tnn}/van-hanh/quy-dinh-van-hanh/rut-gon`
          }
        ]
      },
      {
        title: 'Dữ liệu mưa',
        children: [
          {
            title: 'Hình thế gây mưa lớn',
            path: `${basePaths.tnn}/van-hanh/du-lieu-mua/hinh-the-gay-mua-lon`
          },
          {
            title: 'Mưa hiện tại',
            path: `${basePaths.tnn}/van-hanh/du-lieu-mua/mua-hien-tai`
          },
          {
            title: 'Mưa dự báo',
            path: `${basePaths.tnn}/van-hanh/du-lieu-mua/mua-du-bao`
          }
        ]
      },
      {
        title: 'Dữ liệu dự báo',
        children: [
          {
            title: 'Hồ Đăkđrinh',
            path: `${basePaths.tnn}/van-hanh/ho-dakdrinh`
          },
          {
            title: 'Hồ Nước Trong',
            path: '/#'
          }
        ]
      },
      {
        title: 'Dữ liệu thủy văn',
        children: [
          {
            title: 'Mực nước trạm TV',
            path: `${basePaths.tnn}/van-hanh/du-lieu-thuy-van`
          },
          {
            title: 'Mực nước trạm kiểm soát',
            path: `${basePaths.tnn}/van-hanh/du-lieu-thuy-van`
          }
        ]
      },
      {
        title: 'VH mùa cạn (16/12 - 31/8)',
        children: [
          {
            title: 'Tóm tắt VH ',
            path: '#'
          },
          {
            title: 'Vận hành các hồ',
            path: '#'
          },
          {
            title: 'Chỉ đạo điều hành',
            children: [
              {
                title: 'Trưởng BCH',
                path: `${basePaths.tnn}/van-hanh/tram-thuy-van`
              },
              {
                title: 'Chủ tịch UBND',
                path: `${basePaths.tnn}/van-hanh/tram-thuy-van`
              },
              {
                title: 'Chủ hồ chứa',
                path: `${basePaths.tnn}/van-hanh/tram-thuy-van`
              },
              {
                title: 'QL Thạch Nham',
                path: `${basePaths.tnn}/van-hanh/tram-thuy-van`
              }
            ]
          }
        ]
      },
      {
        title: 'VH mùa lũ (1/9 - 20/9)',
        children: [
          {
            title: 'Phương án vận hành',
            path: `${basePaths.tnn}/van-hanh/van-hanh-lu-som/van-hanh-cac-ho`
          },
          {
            title: 'Chỉ đạo vận hành',
            path: `${basePaths.tnn}/van-hanh/tram-thuy-van`
          }
        ]
      },
      {
        title: 'VH mùa lũ (21/9 - 14/11)',
        children: [
          {
            title: 'Phương án vận hành',
            path: `${basePaths.tnn}/van-hanh/van-hanh-lu-som/van-hanh-cac-ho`
          },
          {
            title: 'Chỉ đạo vận hành',
            path: `${basePaths.tnn}/van-hanh/tram-thuy-van`
          }
        ]
      },

      {
        title: 'VH mùa lũ (15/11 - 15/12)',
        children: [
          {
            title: 'Phương án vận hành',
            path: `${basePaths.tnn}/van-hanh/van-hanh-lu-som/van-hanh-cac-ho`
          },
          {
            title: 'Chỉ đạo vận hành',
            path: `${basePaths.tnn}/van-hanh/tram-thuy-van`
          }
        ]
      },

      {
        title: 'Hướng dẫn sử dụng',
        path: '/pdf/huongdansudung_lienhochua.pdf'
      }
    ],
    tnn_TTDL: [
      {
        title: 'Tài nguyên nước',
        icon: ArrowBack,
        path: basePaths.tnn
      },
      {
        title: 'Nguồn nước',
        children: [
          {
            title: 'Lưu vực sông',
            path: `${basePaths.tnn}/thong-tin-du-lieu/nguon-nuoc/luu-vuc-song`
          },
          {
            title: 'Nguồn nước',
            path: `${basePaths.tnn}/thong-tin-du-lieu/nguon-nuoc/nguon-nuoc`
          },
          {
            title: 'Ao, hồ đầm phá không được san lấp',
            path: `${basePaths.tnn}/thong-tin-du-lieu/ao-khong-san-lap`
          },
          {
            title: 'Hành lang bảo vệ NN',
            path: `${basePaths.tnn}/thong-tin-du-lieu/nguon-nuoc/hanh-lang-bao-ve-nguon-nuoc`
          },
          {
            title: 'Chức năng nguồn nước',
            path: `${basePaths.tnn}/thong-tin-du-lieu/nguon-nuoc/chuc-nang-nguon-nuoc`
          },
          {
            title: 'Dòng chảy tối thiểu',
            path: `${basePaths.tnn}/thong-tin-du-lieu/dong-chay-toi-thieu`
          },
          {
            title: 'Ngưỡng khai thác NDĐ',
            path: `${basePaths.tnn}/thong-tin-du-lieu/nguong-khai-thac-nuoc-duoi-dat`
          },
          {
            title: 'Vùng cấm, hạn chế KTNDĐ',
            path: `${basePaths.tnn}/thong-tin-du-lieu/vung-cam-KT-nuoc-duoi-dat`
          },
          {
            title: 'Mặt cắt sông, suối',
            path: `${basePaths.tnn}/thong-tin-du-lieu/mat-cat-song-suoi`
          }
        ]
      },
      {
        title: 'Số lượng, chất lượng nước',
        children: [
          {
            title: 'Số lượng nước',
            path: `${basePaths.tnn}/thong-tin-du-lieu/so-luong-nuoc`
          },
          {
            title: 'Chất lượng nước',
            path: `${basePaths.tnn}/thong-tin-du-lieu/chat-luong-nuoc`
          }
        ]
      },
      {
        title: 'SL điều tra KTSDN',
        children: [
          {
            title: 'Điều tra KTSD nước mặt',
            path: `${basePaths.tnn}/thong-tin-du-lieu/dieu-tra/nuoc-mat`
          },
          {
            title: 'Điều tra KTSD NDĐ',
            path: `${basePaths.tnn}/thong-tin-du-lieu/dieu-tra/nuoc-duoi-dat`
          },
          {
            title: 'Điều tra xả thải vào NN',
            path: `${basePaths.tnn}/thong-tin-du-lieu/dieu-tra/xa-thai`
          }
        ]
      },
      {
        title: 'Công trình KTSD TNN',
        children: [
          {
            title: 'Phải có giấy phép',
            path: `${basePaths.tnn}/thong-tin-du-lieu/cong-trinh-ktsd-tnn/ktsd-phai-co-giay-phep`
          },
          {
            title: 'Phải kê khai',
            path: `${basePaths.tnn}/thong-tin-du-lieu/cong-trinh-ktsd-tnn/ktsd-phai-ke-khai`
          },
          {
            title: 'Phải đăng ký ',
            path: `${basePaths.tnn}/thong-tin-du-lieu/cong-trinh-ktsd-tnn/ktsd-phai-dang-ky`
          }
        ]
      },
      {
        title: 'HSKT Trạm',
        children: [
          {
            title: 'Nước mặt',
            path: `${basePaths.tnn}/thong-tin-du-lieu/hskt-tram/nuoc-mat`
          },
          {
            title: 'Nước dưới đất',
            path: `${basePaths.tnn}/thong-tin-du-lieu/hskt-tram/nuoc-duoi-dat`
          }
        ]
      },
      {
        title: 'Danh mục NN nội tỉnh',
        children: [
          {
            title: 'Danh mục NN liên tỉnh',
            path: `${basePaths.tnn}/thong-tin-du-lieu/danh-muc-lien-tinh`
          },
          {
            title: 'Danh mục NN nội tỉnh',
            path: `${basePaths.tnn}/thong-tin-du-lieu/danh-muc-mnnt`
          }
        ]
      }
    ],
    dat_dai: [
      {
        title: 'Trang chủ',
        icon: HomeOutline,
        path: '/'
      },
      {
        title: 'Bản đồ địa chính',
        path: '#'
      },
      {
        title: 'Đăng ký đất đai',
        path: '#'
      },
      {
        title: 'Kiểm kê đất đai',
        path: '#'
      },
      {
        title: 'Quy hoạch SDĐ',
        path: '#'
      },
      {
        title: 'Giá đất',
        path: '#'
      },
      {
        title: 'Hướng dẫn sử dụng',
        path: '#'
      }
    ],
    dia_chat_ks: [
      {
        title: 'Trang chủ',
        icon: HomeOutline,
        path: '/'
      },
      {
        title: 'Báo cáo địa chất',
        path: '#'
      },
      {
        title: 'Tiền cấp quyền KTKS',
        path: '#'
      },
      {
        title: 'Cấp phép KTKS',
        path: '#'
      },
      {
        title: 'Giám sát KTKS',
        path: '#'
      },
      {
        title: 'Khu vực dự trữ KS',
        path: '#'
      },
      {
        title: 'Hướng dẫn sử dụng',
        path: '#'
      }
    ],
    moi_truong: [
      {
        title: 'MÔI TRƯỜNG',
        icon: HomeOutline,
        path: '/'
      },
      {
        title: 'Hiện trạng môi trường',
        path: '#'
      },
      {
        title: 'Đa dạng sinh học',
        path: '#'
      },
      {
        title: 'Quy hoạch môi trường',
        path: '#'
      },
      {
        title: 'Nguồn thải ô nhiễm',
        path: '#'
      },
      {
        title: 'Xử lý chất thải',
        path: '#'
      },
      {
        title: 'Tranh chấp, khiếu nại',
        path: '#'
      },
      {
        title: 'Hướng dẫn sử dụng',
        path: '#'
      }
    ],
    kttv: [
      {
        title: 'Trang KTTV',
        icon: HomeOutline,
        path: '/'
      },
      {
        title: 'Quan trắc KTTV',
        path: '#'
      },
      {
        title: 'Dữ liệu KTTV (nguồn khác)',
        path: '#'
      },
      {
        title: 'Bản tin dự báo, cảnh báo',
        path: '#'
      },
      {
        title: 'Hồ sơ kỹ thuật trạm',
        path: '#'
      },
      {
        title: 'HSGP hoạt động',
        path: '#'
      },
      {
        title: 'NCKH,CT, dự án về KTTV',
        path: '#'
      },
      {
        title: 'Văn bản QPPL',
        path: '#'
      },
      {
        title: 'Hướng dẫn sử dụng',
        path: '#'
      }
    ],
    bdks: [
      {
        title: 'Trang BĐKH',
        icon: HomeOutline,
        path: '/'
      },
      {
        title: 'Hiện trạng KH',
        path: '#'
      },
      {
        title: 'Dự báo tác động KH',
        path: '#'
      },
      {
        title: 'Phát thải KNK',
        path: '#'
      },
      {
        title: 'Dữ liệu tầng ô dôn',
        path: '#'
      },
      {
        title: 'Bộ chuẩn khí hậu QG',
        path: '#'
      },
      {
        title: 'Đánh giá KHQG',
        path: '#'
      },
      {
        title: 'KBBĐKH từng thời ký',
        path: '#'
      },
      {
        title: 'Hồ sơ KT trạm GSBĐKH',
        path: '#'
      },
      {
        title: 'Hướng dẫn sử dụng',
        path: '#'
      }
    ],
    do_dac_ban_do: [
      {
        title: 'Trang Đo đạc bản đồ',
        icon: HomeOutline,
        path: '/'
      },
      {
        title: 'Hệ thống đo đạc QG',
        path: '#'
      },
      {
        title: 'Hệ thống không ảnh',
        path: '#'
      },
      {
        title: 'Dữ liệu nền QG',
        path: '#'
      },
      {
        title: 'Biên giới QG',
        path: '#'
      },
      {
        title: 'Địa giới hành chính',
        path: '#'
      },
      {
        title: 'Bản đồ hành chính',
        path: '#'
      },
      {
        title: 'Dữ liệu địa danh',
        path: '#'
      },

      {
        title: 'Dữ liệu khác',
        path: '#'
      },
      {
        title: 'Hướng dẫn sử dụng',
        path: '#'
      }
    ],
    mt_bien_va_hai_dao: [
      {
        title: 'Trang Môi trường Biển và Hải đảo',
        icon: HomeOutline,
        path: '/'
      },
      {
        title: 'Dữ liệu ven biển',
        path: '#'
      },
      {
        title: 'Dữ liệu vật lý biển',
        path: '#'
      },
      {
        title: 'Hệ sinh thái biển',
        path: '#'
      },
      {
        title: 'Môi trường biển',
        path: '#'
      },
      {
        title: 'Hải đảo',
        path: '#'
      },
      {
        title: 'Quy hoạch biển',
        path: '#'
      },
      {
        title: 'Khai thác sử dụng TNN biển',
        path: '#'
      },
      {
        title: 'Thống kê TNN biển',
        path: '#'
      },

      {
        title: 'Hướng dẫn sử dụng',
        path: '#'
      }
    ],
    du_lieu_vien_tham: [
      {
        title: 'Trang Thông tin, dữ liệu về viễn thám',
        icon: HomeOutline,
        path: '/'
      },
      {
        title: 'Cơ sở hạ tầng viễn thám',
        path: '#'
      },
      {
        title: 'Dữ liệu viễn thám',
        path: '#'
      },
      {
        title: 'Quan trắc, giám sát bằng viễn thám',
        path: '#'
      },
      {
        title: 'Ảnh viễn thám',
        path: '#'
      },
      {
        title: 'Siêu dữ liệu viễn thám',
        path: '#'
      },
      {
        title: 'Bản đồ viễn thám',
        path: '#'
      },

      {
        title: 'Hướng dẫn sử dụng',
        path: '#'
      }
    ]
  }

  //quan tri
  if (router.pathname.includes('quan-tri')) {
    return routes.admin
  }

  //tai nguyen nuoc
  if (router.pathname.includes(basePaths.tnn) || router.pathname.includes('/')) {
    if (router.pathname.includes(`${basePaths.tnn}/thong-tin-du-lieu`)) {
      return routes.tnn_TTDL
    }
    if (router.pathname.includes(`${basePaths.tnn}/van-hanh`)) {
      return routes.tnnVHLHC
    }

    return routes.tnn
  }

  //dat dai
  if (router.pathname.includes('dat-dai')) {
    return routes.dat_dai
  }

  //dai chat khoang san
  if (router.pathname.includes('dcks')) {
    return routes.dia_chat_ks
  }

  //moi-truong
  if (router.pathname.includes('moi-truong')) {
    return routes.moi_truong
  }

  // Khi tuong thuy van
  if (router.pathname.includes('kttv')) {
    return routes.kttv
  }

  // Bien doi khi hau
  if (router.pathname.includes('bien-doi-khi-hau')) {
    return routes.bdks
  }

  // Do dac ban do
  if (router.pathname.includes('do-dac-ban-do')) {
    return routes.do_dac_ban_do
  }

  // Moi truong bien va hai dao
  if (router.pathname.includes('moi-truong-bien-va-hai-dao')) {
    return routes.mt_bien_va_hai_dao
  }

  // Du lieu vien tham
  if (router.pathname.includes('du-lieu-vien-tham')) {
    return routes.du_lieu_vien_tham
  }

  // Default return
  return []
}

export default navigation
