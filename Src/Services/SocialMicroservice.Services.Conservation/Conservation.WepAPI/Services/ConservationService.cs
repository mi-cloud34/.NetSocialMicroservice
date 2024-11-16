using AutoMapper;

using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conservation.WepAPI.DbSetting;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Conservation.WepAPI.Model;
using Conservation.WepAPI.Dto;
using Conservation.WepAPI.Response;

namespace Conservation.WepAPI.Services
{
    public class ConservationService : IConservationService
    {
        private readonly IMongoCollection<Conservations> _conservationCollection;
        private readonly IMapper _mapper;
        public ConservationService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _conservationCollection = database.GetCollection<Conservations>(databaseSettings.ConservationCollectionName);

            _mapper = mapper;
        }

        public async Task<Response<ConservationCreateDto>> CreateAsync(ConservationCreateDto conservationCreateDto)
        {
            var newConservation = _mapper.Map<Conservations>(conservationCreateDto);

            newConservation.CreatedTime = DateTime.Now;
            newConservation.UserIds[0] = 1;
            newConservation.UserIds[1] = 2;
            await _conservationCollection.InsertOneAsync(newConservation);

            return Response<ConservationCreateDto>.Success(_mapper.Map<ConservationCreateDto>(newConservation), 200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _conservationCollection.DeleteOneAsync(x => x.Id == id);

            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Conservation not found", 404);
            }
        }
        public async Task<Response<List<ConservationDto>>> GetAllAsync()
        {
            var conservations = await _conservationCollection.Find(course => true).ToListAsync();
               
              

               return Response<List<ConservationDto>>.Success(_mapper.Map<List<ConservationDto>>(conservations), 200);
        }

        //public Task<Response<List<Conservations>>> GetAllByUserIdAsync(string userId)
        //{
        //    var id = await _conservationCollection.Find(i => i. == userId).ToListAsync();
        //    return Response<List<Conservations>>.Success(_mapper.Map<List<Conservations>>(userId), 200);
        //}

        public async Task<Response<ConservationDto>> GetByIdAsync(string id)
        {
            var conservation = await _conservationCollection.Find<Conservations>(x => x.Id == id).FirstOrDefaultAsync();

            if (conservation == null)
            {
                return Response<ConservationDto>.Fail("Conservation not found", 404);
            }
          

            return Response<ConservationDto>.Success(_mapper.Map<ConservationDto>(conservation), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(ConservationDto courseUpdateDto)
        {
            var updateConservation = _mapper.Map<Conservations>(courseUpdateDto);

            var result = await _conservationCollection.FindOneAndReplaceAsync(x => x.Id == updateConservation.Id, updateConservation);

            if (result == null)
            {
                return Response<NoContent>.Fail("Conservation not found", 404);
            }


            return Response<NoContent>.Success(204);
        }

    }
}