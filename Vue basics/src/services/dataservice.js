import Axios from 'axios';
Axios.defaults.baseURL = 'https://art-of-ai-auction.jedlik.cloud';

export default {
    getAllCategories(){
        return Axios.get('/api/categories')  
    },
    getPaintingsByCategoryId(categoryId){
        return Axios.get(`/api/paintings/${categoryId}`)
    },
    getBidsByPaintingId(paintingId){
        return Axios.get(`/api/bids/${paintingId}`)
    },
    saveBid(bid){
        return Axios.post('/users',bid).then(()=>{});
    },
}