export interface PagesNavigationType {
  name: string
  path: string
  logo?: string
  children?: PagesNavigationType[]
}

const pagesNavigation = (): PagesNavigationType[] => {
  return [
    {
      name: 'Đất đai',
      path: '/dat-dai',
      logo: '/images/so1.png'
    },
    {
      name: 'Tài nguyên nước',
      path: '/tai-nguyen-nuoc',
      logo: '/images/so2.png'
    },
    {
      name: 'Hệ thống tưới',
      path: '/he-thong-tuoi',
      logo: '/images/so2.png'
    },
    {
      name: 'Địa chất - Khoáng sản',
      path: '/dcks',
      logo: '/images/so3.png'
    },
    {
      name: 'Môi trường',
      path: '/moi-truong',
      logo: '/images/so4.png'
    },
    {
      name: 'Khí tượng thủy văn',
      path: '/kttv',
      logo: '/images/so5.png'
    },
    {
      name: 'Biến đổi khí hậu',
      path: '/bien-doi-khi-hau',
      logo: '/images/so6.png'
    },
    {
      name: 'Đo đạc và bản đồ',
      path: '/do-dac-ban-do',
      logo: '/images/so7.png'
    },
    {
      name: 'Môi trường biển và hải đảo',
      path: '/moitruongbienvahaidao',
      logo: '/images/so8.png'
    },
    {
      name: 'Dữ liệu viễn thám',
      path: '/du-lieu-vien-tham',
      logo: '/images/so9.png'
    }
  ]
}
export default pagesNavigation
