import { useRouter } from 'next/router'
import { useRequireAuth } from 'src/@core/hooks/useRequireAuth'
import { useEffect, useState, useMemo } from 'react'

import LuongMuaHienTaiView from 'src/views/van-hanh-ho-chua/mua-hien-tai'
import HinhTheThoiTietGayMua from 'src/views/van-hanh-ho-chua/hinh-the-thoi-tiet'
import LuongMuaDuBaoView from 'src/views/van-hanh-ho-chua/mua-du-bao'

import HoChuaTren10Trieu from './ho-chua/tren-10trieu-m3'

type ComponentMap = {
  [key: string]: {
    [key: string]: () => JSX.Element
  }
}

const HethongtuoiPage = () => {
  const router = useRouter()
  const { page, type } = router.query
  const { hasPermission } = useRequireAuth()
  const [hasAccess, setHasAccess] = useState<boolean | null>(null)

  useEffect(() => {
    const checkPermission = async () => {
      const result = await hasPermission(`${router.pathname}/${page}`, 'view')
      setHasAccess(result)
    }
    checkPermission()
  }, [hasPermission, page, router.pathname])

  const components: ComponentMap = useMemo(
    () => ({
      'ho-chua': {
        'tren-10trieu-m3': HoChuaTren10Trieu,
        default: TrangChuVanHanhView
      },
      'so-do-cong-trinh': {
        'quy-trinh-van-hanh-911': Sodocongtrinh911,
        default: TrangChuVanHanhView
      },

      'tom-tat-van-hanh-ct/ho-dakdrinh': {
        'quy-trinh-van-hanh-911': TTVHDakdrinh,
        default: TrangChuVanHanhView
      },

      'tom-tat-van-hanh-ct/ho-son-tay': {
        'quy-trinh-van-hanh-911': TTVHSonTay,
        default: TrangChuVanHanhView
      },

      'tom-tat-van-hanh-ct/ho-nuoc-trong': {
        'quy-trinh-van-hanh-911': TTVHNuocTrong,
        default: TrangChuVanHanhView
      },

      'tom-tat-van-hanh-ct/ho-son-tra1': {
        'quy-trinh-van-hanh-911': TTVHSonTra1,
        default: TrangChuVanHanhView
      },

      'tom-tat-van-hanh-ct/ho-dak-re': {
        'quy-trinh-van-hanh-911': TTVHDakRe,
        default: TrangChuVanHanhView
      },

      'tom-tat-van-hanh-ct/ho-thach-nham': {
        'quy-trinh-van-hanh-911': TTVHThachNham,
        default: TrangChuVanHanhView
      },

      'thong-so': {
        'thong-so-ho-chua': ThongsohochuaView,
        default: TrangChuVanHanhView
      },
      'quan-he-zvf': {
        'thong-so-ho-chua': QuanHeZWFView,
        default: TrangChuVanHanhView
      },

      'quy-dinh-MNVH': {
        'thong-so-ho-chua': QuyDinhMNVH,
        default: TrangChuVanHanhView
      },

      'hinh-the-gay-mua-lon': {
        'du-lieu-mua': HinhTheThoiTietGayMua,
        default: TrangChuVanHanhView
      },

      'ban-do-luoi-tram': {
        'van-hanh-ho-chua': Bandoluoitram,
        default: TrangChuVanHanhView
      },
      'mua-hien-tai': {
        'du-lieu-mua': LuongMuaHienTaiView,
        default: TrangChuVanHanhView
      },
      'mua-du-bao': {
        'du-lieu-mua': LuongMuaDuBaoView,
        default: TrangChuVanHanhView
      },
      // dữ liệu quan trắc ==> hồ chứa

      'dak-drinh': {
        'du-lieu-quan-trac-ho-chua': Dulieuquantrachodakdrinh,
        default: TrangChuVanHanhView
      },
      'nuoc-trong': {
        'du-lieu-quan-trac-ho-chua': Quantrachonuoctrong,
        default: TrangChuVanHanhView
      },

      'son-tra1': {
        'du-lieu-quan-trac-ho-chua': QuantrachoSonTra1,
        default: TrangChuVanHanhView
      },

      'Dak-Re': {
        'du-lieu-quan-trac-ho-chua': QuantrachoDakRe,
        default: TrangChuVanHanhView
      },
      'son-tay': {
        'du-lieu-quan-trac-ho-chua': QuantrachoSonTay,
        default: TrangChuVanHanhView
      },

      //mua lich su
      'tram-an-chi-mua-lichsu': {
        'mua-lich-su': TramAnChiMualichsu,
        default: TrangChuVanHanhView
      },

      //muc nuoc lu lich su
      'tram-chau-o': {
        'muc-nuoc-ha-du': TramChauO,
        default: TrangChuVanHanhView
      },
      'tram-tra-khuc': {
        'muc-nuoc-ha-du': TramTraKhuc,
        default: TrangChuVanHanhView
      },
      'tram-son-giang': {
        'muc-nuoc-ha-du': TramSonGiang,
        default: TrangChuVanHanhView
      },
      'tram-song-ve': {
        'muc-nuoc-ha-du': TramSongVe,
        default: TrangChuVanHanhView
      },

      'tram-an-chi': {
        'muc-nuoc-ha-du': TramAnChi,
        default: TrangChuVanHanhView
      },
      'tram-tra-cau': {
        'muc-nuoc-ha-du': TramTraCau,
        default: TrangChuVanHanhView
      },
      //tomtatvh

      // vận hành mùa lũ
      'ho-dakdrink': {
        'van-hanh-mua-lu': DakdrinhMuaLu1,
        default: TrangChuVanHanhView
      },

'ho-nuoc-trong-vhml1': {
        'van-hanh-mua-lu': NuocTrongMuaLu1,
        default: TrangChuVanHanhView
      },

      //vanhanhcacho
      'truong-bch': {
        'chi-dao': LuongMuaHienTaiView,
        default: TrangChuVanHanhView
      },
      'chu-tich-ubnd': {
        'chi-dao': LuongMuaDuBaoView,
        default: TrangChuVanHanhView
      },
      'chu-ho': {
        'chi-dao': HoDakdrinhView,
        default: TrangChuVanHanhView
      },
      'ql-thach-nham': {
        'chi-dao': HoDakdrinhView,
        default: TrangChuVanHanhView
      },
      'chi-dao': {
        'van-hanh-lu-1/9-20/9': TomTatVanHanhLuSom,
        'van-hanh-lu-21/9-14/11': TomTatVanHanhLuSom,
        'van-hanh-lu-15/11-15/12': TomTatVanHanhLuSom,
        default: TrangChuVanHanhView
      }
    }),
    []
  )

  const typedType = Array.isArray(type) ? type[0] : type
  const typedPage = Array.isArray(page) ? page[0] : page

  const Component =
    typedType && typedPage && components[typedType]
      ? components[typedType][typedPage] || components[typedType].default || <div>Loading...</div>
      : TrangChuVanHanhView

  if (hasAccess === null) {
    return <div>Loading...</div>
  }

  return <Component />
}

export default HethongtuoiPage
