import { defineStore } from "pinia";

export const usePaintingBidStore = defineStore({
    id: 'PaintingBidStore',
    state: ()=>({ 
        kivPainting: -1
     }),
    getters:{
        getPainting(state){
            
            return state.kivalasztottPainting;
        },
    },
    actions:{
        PaintingKivalasztas(painting){
            this.kivPainting = painting
        }
    }
});