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
        title: 'TÀI NGUYÊN NƯỚC',
        icon: HomeOutline,
        path: basePaths.tnn
      },
      {
        title: 'Giám sát',
        children: [
          {
            sectionTitle: 'Công trình',
            path: `${basePaths.tnn}/giam-sat/cong-trinh`
          },
          {
            title: 'Bản đồ công trình',
            path: `${basePaths.tnn}/giam-sat/cong-trinh`
          },
          {
            title: 'Nước mặt',
            path: `${basePaths.tnn}/giam-sat/cong-trinh/nuoc-mat`
          },
          {
            title: 'Nước dưới đất',
            path: `${basePaths.tnn}/giam-sat/cong-trinh/nuoc-duoi-dat`
          },
          {
            title: 'Xả thải',
            path: `${basePaths.tnn}/giam-sat/cong-trinh/xa-thai`
          },

          {
            sectionTitle: 'Quan trắc',
            path: `${basePaths.tnn}/giam-sat/quan-trac`
          },
          {
            title: 'Nước mặt',
            path: `${basePaths.tnn}/giam-sat/quan-trac/nuoc-mat`
          },
          {
            title: 'Nước dưới đất',
            path: `${basePaths.tnn}/giam-sat/quan-trac/nuoc-duoi-dat`
          },
          {
            title: 'Xả thải',
            path: `${basePaths.tnn}/giam-sat/quan-trac/xa-thai`
          },

          {
            sectionTitle: 'Giám sát',
            path: `${basePaths.tnn}/giam-sat/giam-sat`
          },
          {
            title: 'Đăng ký kết nối',
            path: `${basePaths.tnn}/giam-sat/giam-sat/yeu-cau-ket-noi`
          },
          {
            title: 'QL đăng ký kết nối',
            path: `${basePaths.tnn}/giam-sat/giam-sat/quan-ly-yeu-cau-ket-noi`
          },
          {
            title: 'KTSD nước mặt',
            path: `${basePaths.tnn}/giam-sat/giam-sat/nuoc-mat`
          },
          {
            title: 'KTSD nước dưới đất',
            path: `${basePaths.tnn}/giam-sat/giam-sat/nuoc-duoi-dat`
          },
          {
            title: 'Xả thải',
            path: `${basePaths.tnn}/giam-sat/giam-sat/xa-thai`
          }
        ]
      },
      {
        title: 'Cấp phép',
        children: [
          {
            sectionTitle: 'Giấy phép',
            path: `${basePaths.tnn}/cap-phep/giay-phep`
          },
          {
            title: 'Thống kê',
            path: `${basePaths.tnn}/cap-phep`
          },
          {
            title: 'Kết quả cấp phép',
            path: `${basePaths.tnn}/cap-phep/giay-phep/ket-qua-cap-phep`
          },
          {
            title: 'Nước mặt',
            path: `${basePaths.tnn}/cap-phep/giay-phep/nuoc-mat`
          },
          {
            title: 'KTSD Nước dưới đất',
            path: `${basePaths.tnn}/cap-phep/giay-phep/nuoc-duoi-dat/khai-thac-su-dung`
          },
          {
            title: 'Thăm dò nước dưới đất',
            path: `${basePaths.tnn}/cap-phep/giay-phep/nuoc-duoi-dat/tham-do`
          },
          {
            title: 'HNK nước dưới đất',
            path: `${basePaths.tnn}/cap-phep/giay-phep/nuoc-duoi-dat/hanh-nghe-khoan`
          },
          {
            title: 'Xả thải',
            path: `${basePaths.tnn}/cap-phep/giay-phep/xa-thai`
          },
          {
            sectionTitle: 'Tiền cấp quyền',
            path: `${basePaths.tnn}/cap-phep/tien-cap-quyen`
          },
          {
            title: 'Bộ cấp',
            path: `${basePaths.tnn}/cap-phep/tien-cap-quyen/bo-cap`
          },
          {
            title: 'Tỉnh cấp',
            path: `${basePaths.tnn}/cap-phep/tien-cap-quyen/tinh-cap`
          },
          {
            sectionTitle: 'Thanh tra - kiểm tra',
            path: `${basePaths.tnn}/cap-phep/thanh-tra-kiem-tra`
          },
          {
            title: 'Thanh tra - kiểm tra',
            path: `${basePaths.tnn}/cap-phep/thanh-tra-kiem-tra`
          }
          // {
          //   title: 'Tổ chức - cá nhân',
          //   path: `${basePaths.tnn}/cap-phep/to-chuc-ca-nhan`
          // }
        ]
      },
      {
        title: 'Kiểm kê TNN',
        children: [
          {
            sectionTitle: 'Tổng hợp chỉ tiêu KK'
          },
          {
            title: 'Lưu vực sông Trà Khúc',
            path: `${basePaths.tnn}/kiem-ke/tong-hop-chi-tieu/lvs-tra-khuc`
          },
          {
            title: 'Tỉnh Quảng Ngãi',
            path: `${basePaths.tnn}/kiem-ke/tong-hop-chi-tieu/kk-tnn`
          },
          {
            sectionTitle: 'Nước mưa'
          },
          {
            title: 'Tổng lượng mưa',
            path: `${basePaths.tnn}/kiem-ke/nuoc-mua`
          },
        
          {
            sectionTitle: 'Nước mặt'
          },
          {
            title: 'Số lượng nguồn nước mặt',
            path: `${basePaths.tnn}/kiem-ke/nuoc-mat/so-luong`
          },
          {
            title: 'Lượng nước mặt',
            path: `${basePaths.tnn}/kiem-ke/nuoc-mat/tong-luong`
          },
          {
            title: 'Chất lượng nước mặt',
            path: `${basePaths.tnn}/kiem-ke/nuoc-mat/chat-luong-nuoc`
          },
          {
            title: 'KTSD nước mặt',
            path: `${basePaths.tnn}/kiem-ke/nuoc-mat/ktsd-nuoc-mat`
          },

          {
            sectionTitle: 'Nước dưới đất'
          },
          {
            title: 'Số lượng nguồn nước DĐ',
            path: `${basePaths.tnn}/kiem-ke/nuoc-duoi-dat/so-luong`
          },
          {
            title: 'Lượng nước dưới đất',
            path: `${basePaths.tnn}/kiem-ke/nuoc-duoi-dat/tong-luong`
          },
          {
            title: 'Khai thác, sử dụng NDĐ',
            path: `${basePaths.tnn}/kiem-ke/nuoc-duoi-dat/khai-thac`
          },
          {
            title: 'Chất lượng NDĐ',
            path: `${basePaths.tnn}/kiem-ke/nuoc-duoi-dat/kiem-ke-CLN-duoi-dat`
          },

          {
            sectionTitle: 'Nước biển'
          },
          {
            title: 'KTSD nước biển',
            path: `${basePaths.tnn}/kiem-ke/kiem-ke-nuoc-bien`
          },

          {
            sectionTitle: 'Xả thải'
          },
          {
            title: 'Xả thải vào NN',
            path: `${basePaths.tnn}/kiem-ke/nuoc-thai`
          },

          {
            sectionTitle: 'Báo cáo KQKK'
          },
          {
            title: 'Báo cáo kết quả',
             path: '/pdf/baocaokiemke.pdf'
          },
          {
            sectionTitle: 'Mẫu phiếu điều tra'
          },
          {
            title: 'Mẫu phiếu điều tra',
            path: `${basePaths.tnn}/kiem-ke/mau-phieu-kiem-ke`
          },
        ]
      },
      {
        title: 'Thông tin dữ liệu',
        path: `${basePaths.tnn}/thong-tin-du-lieu`
      },
      {
        title: 'Báo cáo biểu mẫu',
        children: [
          {
            title: 'Báo cáo biểu mẫu TNN',
            path: `${basePaths.tnn}/bao-cao`
          },
          {
            title: 'kế hoạch KTSDN',
            path: '#'
          }
        ]
      },
      {
        title: 'Vận hành liên hồ chứa',
        path: `${basePaths.tnn}/van-hanh`
      },
      {
        title: 'Đánh giá KNTN nước thải',
        children: [
          {
            title: 'QCVN_08_2023',
            path: `${basePaths.tnn}/xa-thai/nguon-nuoc-song/cln`
          },
          {
            title: 'Phân đoạn sông',
            path: `${basePaths.tnn}/xa-thai/nguon-nuoc-song/phan-doan-song`
          },
          {
            sectionTitle: 'KNTN nước thải sông,suối hiện trạng'
          },
          {
            title: 'Dữ liệu nguồn nước nhận',
            path: `${basePaths.tnn}/xa-thai/nguon-nuoc-song/du-lieu-nguon-nhan`
          },
          {
            title: 'Dữ liệu nguồn nước thải',
            path: `${basePaths.tnn}/xa-thai/nguon-nuoc-song/du-lieu-nguon-thai`
          },
          {
            title: 'Tải lượng ô nhiễm',
            path: `${basePaths.tnn}/xa-thai/nguon-nuoc-song/tai-luong-o-nhiem`
          },
          {
            title: 'Khả năng TNNT sông,suối',
            path: `${basePaths.tnn}/xa-thai/nguon-nuoc-song/kha-nang-tiep-nhan-nuoc-thai-song`
          },
          {
            sectionTitle: 'KNTN nước thải sông,suối dự báo'
          },
          {
            title: 'Dữ liệu nguồn nước nhận',
            path: `${basePaths.tnn}/xa-thai/nguon-nuoc-song/du-bao/du-lieu-nguon-nhan`
          },
          {
            title: 'Dữ liệu nguồn nước thải',
            path: `${basePaths.tnn}/xa-thai/nguon-nuoc-song/du-bao/du-lieu-nguon-thai`
          },
          {
            title: 'Tải lượng ô nhiễm',
            path: `${basePaths.tnn}/xa-thai/nguon-nuoc-song/du-bao/tai-luong-o-nhiem`
          },
          {
            title: 'Khả năng TNNT sông,suối',
            path: `${basePaths.tnn}/xa-thai/nguon-nuoc-song/du-bao/kha-nang-tiep-nhan-nuoc-thai-song`
          },

          {
            sectionTitle: 'KNTN nước thải ao,hồ'
          },
          {
            title: 'QCVN_08_2023',
            path: `${basePaths.tnn}/xa-thai/nguon-nuoc-ao/cln`
          },
          {
            title: 'Thông tin ao,hồ',
            path: `${basePaths.tnn}/xa-thai/nguon-nuoc-ao/thong-tin-ao-ho`
          },
          {
            title: 'Khả năng TNNT ao,hồ',
            path: `${basePaths.tnn}/xa-thai/nguon-nuoc-ao/kha-nang-tiep-nhan-ao-ho`
          },
          {
            title: 'Dự báo KNTNNT ao,hồ',
            path: `${basePaths.tnn}/xa-thai/nguon-nuoc-ao/du-bao`
          }
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
